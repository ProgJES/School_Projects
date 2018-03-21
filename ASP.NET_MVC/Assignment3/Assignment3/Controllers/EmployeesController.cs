using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment3.Controllers
{
    public class EmployeesController : Controller
    {
        private Manager m = new Manager();
        // GET: Employees
        public ActionResult Index()
        {
            //fetch the collection
            var emp = m.EmployeeGetAll();

            return View(emp);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            var emp = m.EmployeeGetById(id);

            return View(emp);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            var o = m.EmployeeGetById(id.GetValueOrDefault());

            if(o == null)
            {
                return HttpNotFound();
            }

            var editForm = AutoMapper.Mapper.Map<EmployeeBase, EmployeeEditForm>(o);

            return View(editForm);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, EmployeeEdit newItem)
        {
            try
            {
                // TODO: Add update logic here
                if(!ModelState.IsValid)
                {
                    return RedirectToAction("edit", new { id = newItem.EmployeeId });
                }
                if(id.GetValueOrDefault() != newItem.EmployeeId)
                {
                    return RedirectToAction("Index");
                }

                var editform = m.EmployeeEdit(newItem);

                if(editform == null)
                {
                    return RedirectToAction("edit", new { id = newItem.EmployeeId });
                }
                else
                {
                    return RedirectToAction("details", new { id = newItem.EmployeeId });
                }
               
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

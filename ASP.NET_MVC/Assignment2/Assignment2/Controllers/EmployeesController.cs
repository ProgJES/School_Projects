using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.Controllers
{
    public class EmployeesController : Controller
    {
        //Reference to a manage object
        private Manager m = new Manager();
        // GET: Employees
        public ActionResult Index()
        {
            //Fetch the collection
            var emp = m.EmployeeGetAll();

            return View(emp);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            var emp = m.EmployeeGetById(id.GetValueOrDefault());

            if(emp == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(emp);
            }
     
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(EmployeeAdd newItem)
        {
            // Validate the input
            if (!ModelState.IsValid)
            {
                 return View(newItem);
            }
            //Process the input
            var addedItem = m.EmployeeAdd(newItem);

             if (addedItem == null)
             {
                return View(newItem);
             }
             
             return RedirectToAction("details", new { id = addedItem.EmployeeId }); 
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
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

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment8.Controllers
{
    public class TracksController : Controller
    {
        private Manager m = new Manager();
        // GET: Tracks
        public ActionResult Index()
        {
            
            return View(m.TrackGetAll());
        }

        // GET: Tracks/Details/5
        public ActionResult Details(int? id)
        {
            return View(m.TrackGetById(id));
        }

        // GET: Tracks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tracks/Create
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

        // GET: Tracks/Edit/5
        [Authorize(Roles = "Coordinator")]
        public ActionResult Edit(int? id)
        {
            var o = m.TrackGetById(id.GetValueOrDefault());

            if(o == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = Mapper.Map<TrackWithDetail, TrackEditForm>(o);

                return View(form);
            }
            
        }

        // POST: Tracks/Edit/5
        [Authorize(Roles = "Coordinator")]
        [HttpPost]
        public ActionResult Edit(int? id, TrackEdit newItem)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("edit", new { id = newItem.Id });
            }
            if(id.GetValueOrDefault() != newItem.Id)
            {
                return RedirectToAction("index");
            }

            var editItem = m.TrackEdit(newItem);

            if(editItem == null)
            {
                return RedirectToAction("edit", new { id = newItem.Id });
            }
            else
            {
                return RedirectToAction("details", new { id = newItem.Id });
            }
        }

        [Authorize(Roles = "Coordinator")]
        // GET: Tracks/Delete/5
        public ActionResult Delete(int? id)
        {
            var itemToDelete = m.TrackGetById(id.GetValueOrDefault());

            if(itemToDelete == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(itemToDelete);
            }
        }
        [Authorize(Roles = "Coordinator")]
        // POST: Tracks/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            var result = m.TrackDelete(id.GetValueOrDefault());

            // "result" will be true or false
            // We probably won't do much with the result, because 
            // we don't want to leak info about the delete attempt

            // In the end, we should just redirect to the list view

            return RedirectToAction("index");
        }
    }
}

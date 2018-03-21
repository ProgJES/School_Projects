using Assignment9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment9.Controllers
{
    [Authorize]
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
            return View(m.TrackGetById(id.GetValueOrDefault()));
        }

        // GET: Tracks/Create
        public ActionResult Create()
        {
            var form = new TrackAddForm();

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
        [Authorize(Roles = "Clerk")]
        public ActionResult Edit(int? id)
        {
            var o = m.TrackGetById(id.GetValueOrDefault());
           
            if(o == null)
            {
                return HttpNotFound();
            }

            var form = new TrackEditForm();
            form.TrackName = o.Name;
            return View(form);
        }

        // POST: Tracks/Edit/5
        [Authorize(Roles = "Clerk")]
        [HttpPost]
        public ActionResult Edit(int? id, TrackEdit newItem)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("edit", new { id = newItem.Id });
            }
            if (id.GetValueOrDefault() != newItem.Id)
            {
                return RedirectToAction("index");
            }

            var editedItem = m.TrackEdit(newItem);
            if (editedItem == null)
            {
                return RedirectToAction("details", new { id = newItem.Id });
            }
            else
            {
                return RedirectToAction("details", new { id = newItem.Id });
            }
        }

        // GET: Tracks/Delete/5
        [Authorize(Roles = "Clerk")]
        public ActionResult Delete(int? id)
        {
            var ItemToDelete = m.TrackGetById(id.GetValueOrDefault());

            if(ItemToDelete == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(ItemToDelete);
            }
        }

        // POST: Tracks/Delete/5
        [Authorize(Roles = "Clerk")]
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            var result = m.TrackDelete(id.GetValueOrDefault());

            return RedirectToAction("index");
        }
    }
}

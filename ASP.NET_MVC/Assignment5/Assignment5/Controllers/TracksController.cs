using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment5.Controllers
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
            var form = new TrackAddForm();

            form.AlbumList = new SelectList(m.AlbumGetAll(), "AlbumId", "Title");
            form.MediaTypeList = new SelectList(m.MediaTypeGetAll(), "MediaTypeId", "Name");

            return View(form);
        }

        // POST: Tracks/Create
        [HttpPost]
        public ActionResult Create(TrackAdd newItem)
        {
            if (!ModelState.IsValid)
            {
                return View(newItem);
            }
            
            var addItem = m.TrackAdd(newItem);

            if(addItem == null)
            {
                return View(newItem);
            }
            return RedirectToAction("details", new { id = addItem.TrackId });
        }

        // GET: Tracks/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Tracks/Edit/5
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

        // GET: Tracks/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tracks/Delete/5
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

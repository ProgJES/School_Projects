using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment9.Controllers
{
    [Authorize]
    public class AlbumsController : Controller
    {
        
        private Manager m = new Manager();
        // GET: Albums
        public ActionResult Index()
        {
            return View(m.AlbumGetAll());
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            return View(m.AlbumGetById(id));
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
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
        //GET : Tracks/Create
        [Authorize(Roles = "Clerk")]
        [Route("albums/{id}/addtrack")]
        public ActionResult AddTrack(int? id)
        {
            var album = m.AlbumGetById(id.GetValueOrDefault());

            var form = new TrackAddForm();

            form.GenreList = new SelectList(m.GenreGetAll(), "Id", "Name");
            
            
            form.AlbumName = album.Name;

            return View(form);
        }

        //POST : Track/Create
        [Authorize(Roles = "Clerk")]
        [Route("albums/{id}/addtrack")]
        [HttpPost, ValidateInput(false)]
        public ActionResult AddTrack(int? id, TrackAdd newItem)
        {
            if(!ModelState.IsValid)
            {
                return View(newItem);
            }
            var addedItem = m.TrackAdd(id.GetValueOrDefault(), newItem);

            if(addedItem == null)
            {
                return View(addedItem);
            }
            else
            {
                return RedirectToAction("../tracks/details", new { id = addedItem.Id });
            }
        }
        // GET: Albums/Edit/5
        [Authorize(Roles = "Coordinator")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Albums/Edit/5
        [Authorize(Roles = "Coordinator")]
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

        // GET: Albums/Delete/5
        [Authorize(Roles = "Coordinator")]
        public ActionResult Delete(int? id)
        {
            var itemToDelete = m.AlbumGetById(id.GetValueOrDefault());

            if(itemToDelete == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(itemToDelete);
            }
            
        }

        // POST: Albums/Delete/5
        [Authorize(Roles = "Coordinator")]
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            var result = m.AlbumDelete(id.GetValueOrDefault());

            // "result" will be true or false
            // We probably won't do much with the result, because 
            // we don't want to leak info about the delete attempt

            // In the end, we should just redirect to the list view
            return RedirectToAction("index");
        }
    }
}

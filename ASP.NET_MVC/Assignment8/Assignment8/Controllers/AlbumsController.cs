using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment8.Controllers
{
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

        /*Create method of track*/
        [Authorize(Roles = "Clerk")]
        [Route("albums/{id}/addtrack")]
        public ActionResult AddTrack(int? id)
        {
            var o = m.AlbumGetById(id);
            
            if(o == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = new TrackAddForm();
                form.GenreList = new SelectList(m.GenreGetAll(), "Id", "Name");

                form.AlbumId = o.Id;
                form.AlbumName = o.Name;

                return View(form);  
            }
        }
        [Authorize(Roles = "Clerk")]
        [Route("albums/{id}/addtrack")]
        [HttpPost]
        public ActionResult AddTrack(TrackAdd newItem)
        {
            newItem.Clerk = HttpContext.User.Identity.Name;

            if(!ModelState.IsValid)
            {
                return View(newItem);
            }
            else
            {
                var addedItem = m.TrackAdd(newItem);

                if(addedItem == null)
                {
                    return View(addedItem);
                }
                else
                {
                    return RedirectToAction("../tracks/details", new { id = addedItem.Id });
                }
            }
        }
        // GET: Albums/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Albums/Edit/5
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Albums/Delete/5
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

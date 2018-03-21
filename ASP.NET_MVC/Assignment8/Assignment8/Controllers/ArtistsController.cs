using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment8.Controllers
{
    
    public class ArtistsController : Controller
    {
        private Manager m = new Manager();
        // GET: Artists
        public ActionResult Index()
        {
            return View(m.ArtistGetAll());
        }

        // GET: Artists/Details/5
        public ActionResult Details(int? id)
        {
            return View(m.ArtistGetById(id));
        }

        /*Only the user who is role of Executive able to create new artist*/
        [Authorize(Roles = "Executive")]
        // GET: Artists/Create
        public ActionResult Create()
        {
            var form = new ArtistAddForm();
            form.GenreList = new SelectList(m.GenreGetAll(), "Id", "Name");

            return View(form);
        }
        [Authorize(Roles = "Executive")]
        // POST: Artists/Create
        [HttpPost]
        public ActionResult Create(ArtistAdd newItem)
        {
            newItem.Executive = HttpContext.User.Identity.Name;

            if(!ModelState.IsValid)
            {
                return View(newItem);
            }
            var addedItem = m.ArtistAdd(newItem);

            if(addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("details", new { id = addedItem.Id });
            }
        }
        /*Create method for album inside artist*/
        [Authorize(Roles = "Coordinator")]
        [Route("artists/{id}/addalbum")]
        public ActionResult AddAlbum(int? id)
        {
            var o = m.ArtistGetById(id.GetValueOrDefault());
            if(o == null)
            {
                return HttpNotFound();
            }
            else
            {
                int? thisId = id;
                var form = new AlbumAddForm();
                var selectedValue = new List<int> { o.Id };
                form.GenreList = new SelectList(m.GenreGetAll(), "Id", "Name");
                
                form.ArtistList = new MultiSelectList
                (
                    items: m.ArtistGetAll(),
                    dataTextField: "Name",
                    dataValueField: "Id",
                    selectedValues: selectedValue
                );
                form.TrackList = new MultiSelectList
                (
                    items: m.TrackGetAll(),
                    dataTextField: "Name",
                    dataValueField: "Id",
                    selectedValues: selectedValue
                );

                form.ArtistName = o.Name;
                return View(form);
            }
        }
        /*Post*/
        [Authorize(Roles = "Coordinator")]
        [Route("artists/{id}/addalbum")]
        [HttpPost]
        public ActionResult AddAlbum(AlbumAdd newItem)
        {
            var name = newItem.Name;
            IEnumerable<int> aid = newItem.ArtistIds;
            newItem.Coordinator = HttpContext.User.Identity.Name;
            
            if(!ModelState.IsValid)
            {
                return View(newItem);
            }
            else
            {
                var addedItem = m.AlbumAdd(newItem);
                if(addedItem == null)
                {
                    return View(addedItem);
                }
                else
                {
                    return RedirectToAction("../albums/details", new { id = addedItem.Id });
                }
            }
        }
        // GET: Artists/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Artists/Edit/5
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

        // GET: Artists/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Artists/Delete/5
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
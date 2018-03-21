using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment9.Controllers
{
    [Authorize]
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
            var o = m.ArtistGetByWithContentInfo(id.GetValueOrDefault());

            if (o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }
        public ActionResult DetailWithContentInfo(int? id)
        {
            var o = m.ArtistGetByWithContentInfo(id.GetValueOrDefault());
            
            if(o == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(o);
            }
        }
        [Authorize(Roles = "Executive")]
        // GET: Artists/Create
        public ActionResult Create()
        {
            var form = new ArtistAddForm();
            form.GenreList = new SelectList(m.GenreGetAll(), "Id", "Name");

            return View(form);
        }

        // POST: Artists/Create
        [Authorize(Roles = "Executive")]
        [HttpPost, ValidateInput(false)]
        public ActionResult Create(ArtistAdd newItem)
        {
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

        // GET : Artists/AddAlbum
        [Authorize(Roles = "Coordinator")]
        [Route("artists/{id}/addalbum")]
        public ActionResult AddAlbum(int? id)
        {
            var artist = m.ArtistGetById(id.GetValueOrDefault());

            var form = new AlbumAddForm();
            form.GenreList = new SelectList(m.GenreGetAll(), "Id", "Name");
            form.ArtistName = artist.Name;

            return View(form);
        }
        [Authorize(Roles = "Coordinator")]
        [Route("artists/{id}/addalbum")]
        [HttpPost, ValidateInput(false)]
        public ActionResult AddAlbum(AlbumAdd newItem)
        {
            if(!ModelState.IsValid)
            {
                return View(newItem);
            }

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
        // GET : Artist/AddMediaItem
        [Authorize(Roles = "Coordinator")]
        [Route("artists/{id}/addmediaitem")]
        public ActionResult AddMediaItem(int? id)
        {
            var o = m.ArtistGetById(id.GetValueOrDefault());

            if(o == null)
            {
                return HttpNotFound();
            }
            else
            {
                //Create form
                var form = new MediaItemAddForm();
                //Configure its property value
                form.ArtistId = o.Id;
                form.ArtistInfo = $"{o.Name}, {o.Genre}, {o.Portrayal}";
                form.ArtistName = o.Name;
                return View(form);
            }
        }
        [Authorize(Roles = "Coordinator")]
        [Route("artists/{id}/addmediaitem")]
        [HttpPost]
        public ActionResult AddMediaItem(int? id, MediaItemAdd newItem)
        {
            if (!ModelState.IsValid && id.GetValueOrDefault() == newItem.ArtistId)
            {
                return View(newItem);
            }
            newItem.ArtistId = id.GetValueOrDefault();
            var addedItem = m.ArtistMediaItemAdd(newItem);

            if (addedItem == null)
            {
                return View(newItem);
            }
            else
            {
                return RedirectToAction("Details", new { id = addedItem.Id });
            }

        }
        // GET: Artists/Edit/5
        [Authorize(Roles = "Executive")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Artists/Edit/5
        [Authorize(Roles = "Executive")]
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
        [Authorize(Roles = "Executive")]
        public ActionResult Delete(int? id)
        {
            var itemToDelete = m.ArtistGetById(id.GetValueOrDefault());

            if (itemToDelete == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                return View(itemToDelete);
            }
        }

        // POST: Artists/Delete/5
        [Authorize(Roles = "Executive")]
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            var result = m.ArtistDelete(id.GetValueOrDefault());

            // "result" will be true or false
            // We probably won't do much with the result, because 
            // we don't want to leak info about the delete attempt

            // In the end, we should just redirect to the list view
            return RedirectToAction("index");
        } 
    }
}

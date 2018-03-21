using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment6.Controllers
{
    public class PlaylistsController : Controller
    {
        private Manager m = new Manager();
        // GET: Playlists
        public ActionResult Index()
        {
            return View(m.PlaylistGetAllWithDetail());
        }

        // GET: Playlists/Details/5
        public ActionResult Details(int? id)
        {
            return View(m.PlaylistGetById(id));
        }

        // GET: Playlists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Playlists/Create
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

        // GET: Playlists/Edit/5
        public ActionResult Edit(int? id)
        {
            var o = m.PlaylistGetById(id.GetValueOrDefault());
            if(o == null)
            {
                return HttpNotFound();
            }
            else
            {
                var form = Mapper.Map<PlaylistBase, PlaylistEditTracksForm>(o);

                var selectedValues = o.Tracks.Select(t => t.TrackId);

                form.NowOnPlayList = o.Tracks;
               
                form.playlistlist = new MultiSelectList(
                       items: m.TrackGetAll(),
                       dataValueField: "TrackId",
                       dataTextField: "Description",
                       selectedValues: selectedValues);
                return View(form);
            }
            
        }

        // POST: Playlists/Edit/5
        //Use select() method in order to print only name of track
        [HttpPost]
        public ActionResult Edit(int? id, PlaylistEditTracks newItem)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("edit", new { id = newItem.playlistId });
            }
            if(id.GetValueOrDefault() != newItem.playlistId)
            {
                return RedirectToAction("index");
            }

            var editedItem = m.PlaylistEditTracks(newItem);

            if (editedItem == null)
            {
                return RedirectToAction("Details", new { id = newItem.playlistId });
            }
            else
            {
                return RedirectToAction("Details", new { id = newItem.playlistId });
            }
        }

        // GET: Playlists/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Playlists/Delete/5
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

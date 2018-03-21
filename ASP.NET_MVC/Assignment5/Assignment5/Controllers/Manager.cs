using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using Assignment5.Models;

namespace Assignment5.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        public Manager()
        {
            // If necessary, add constructor code here
        }
        //Get all manager methods
        public IEnumerable<AlbumBase> AlbumGetAll()
        {
            return Mapper.Map<IEnumerable<Album>, IEnumerable<AlbumBase>>(ds.Albums.OrderBy(a => a.AlbumId));
        }
        public IEnumerable<MediaTypeBase> MediaTypeGetAll()
        {
            return Mapper.Map<IEnumerable<MediaType>, IEnumerable<MediaTypeBase>>(ds.MediaTypes.OrderBy(m => m.MediaTypeId));
        }
        public IEnumerable<TrackBase> TrackGetAll()
        {
            return Mapper.Map<IEnumerable<Track>, IEnumerable<TrackWithDetail>>(ds.Tracks.OrderBy(t => t.TrackId));
        }
        public IEnumerable<ArtistBase> ArtistGetALL()
        {
            return Mapper.Map<IEnumerable<Artist>, IEnumerable<ArtistBase>>(ds.Artists.OrderBy(a => a.ArtistId));
        }
        //Get one manager methods
        public AlbumBase AlbumGetById(int? id)
        {
            var o = ds.Albums.Find(id);

            return (o == null) ? null : Mapper.Map<Album, AlbumBase>(o);
        }
        public MediaTypeBase MediaTypeGetById(int? id)
        {
            var o = ds.MediaTypes.Find(id);

            return (o == null) ? null : Mapper.Map<MediaType, MediaTypeBase>(o);
        }
        public TrackWithDetail TrackGetById(int? id)
        {
            var o = ds.Tracks.Include("Album.Artist")
                             .Include("MediaType")
                             .SingleOrDefault(t => t.TrackId == id);

            return Mapper.Map<Track, TrackWithDetail>(o);
        }
        /*Track Add Method*/
        public TrackWithDetail TrackAdd(TrackAdd newItem)
        {
            var a = ds.Albums.Find(newItem.AlbumId);
            var s = ds.MediaTypes.Find(newItem.MediaTypeId);

            if(a == null)
            {
                return null;
            }
            if(s == null)
            {
                return null;
            }
            else
            {
               var addItem = ds.Tracks.Add(Mapper.Map<TrackAdd, Track>(newItem));
                addItem.Album = a;
                addItem.MediaType = s;

                ds.SaveChanges();

                return (addItem == null) ? null : Mapper.Map<Track, TrackWithDetail>(addItem);
            }
            
        }

        // Add methods below
        // Controllers will call these methods
        // Ensure that the methods accept and deliver ONLY view model objects and collections
        // The collection return type is almost always IEnumerable<T>

        // Suggested naming convention: Entity + task/action
        // For example:
        // ProductGetAll()
        // ProductGetById()
        // ProductAdd()
        // ProductEdit()
        // ProductDelete()
    }
}
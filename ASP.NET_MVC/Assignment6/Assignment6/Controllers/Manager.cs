using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// new...
using AutoMapper;
using Assignment6.Models;

namespace Assignment6.Controllers
{
    public class Manager
    {
        // Reference to the data context
        private DataContext ds = new DataContext();

        public Manager()
        {
            ds.Configuration.ProxyCreationEnabled = false;
            ds.Configuration.LazyLoadingEnabled = false;
        }

     
        // Add methods below
        // Controllers will call these methods
        // Ensure that the methods accept and deliver ONLY view model objects and collections
        // The collection return type is almost always IEnumerable<T>

       /*Get all method*/
       public IEnumerable<PlaylistBase> PlaylistGetAll()
        { 
            return Mapper.Map<IEnumerable<Playlist>, IEnumerable<PlaylistBase>>(ds.Playlists);
        }
        public IEnumerable<PlaylistWithDetail> PlaylistGetAllWithDetail()
        {
            return Mapper.Map<IEnumerable<Playlist>, IEnumerable<PlaylistWithDetail>>(ds.Playlists.Include("Tracks"));
        }
        public IEnumerable<TrackBase> TrackGetAll()
        {
            return Mapper.Map<IEnumerable<Track>, IEnumerable<TrackBase>>(ds.Tracks.OrderBy(t => t.Name));
        }

        /*Get one method*/
        public PlaylistWithDetail PlaylistGetById(int? id)
        {
            var o = ds.Playlists.Include("Tracks").SingleOrDefault(p => p.PlaylistId == id);

            return Mapper.Map<Playlist, PlaylistWithDetail>(o);
        }

        /*Edit methods*/
        public PlaylistWithDetail PlaylistEditTracks(PlaylistEditTracks newItem)
        {
            var o = ds.Playlists.Include("Tracks").SingleOrDefault(p => p.PlaylistId == newItem.playlistId);
            
            if(o == null)
            {
                return null;
            }
            else
            {
                //Clear the existing collection
                o.Tracks.Clear();

                foreach(var item in newItem.TrackIds)
                {
                    var a = ds.Tracks.Find(item);
                    o.Tracks.Add(a);
                }
                ds.SaveChanges();

                return Mapper.Map<Playlist, PlaylistWithDetail>(o);
            }
        }
    }
}
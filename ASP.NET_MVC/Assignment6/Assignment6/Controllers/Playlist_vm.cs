using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment6.Controllers
{
    public class PlaylistBase
    {
        public PlaylistBase()
        {
            
        }
        [Key]
        public int PlaylistId { get; set; }

        [StringLength(120)]
        public string Name { get; set; }

        //Automatically counts number of tracks that belongs to the playlist
        public int TracksCount { get; set; }
        
    }

    public class PlaylistWithDetail : PlaylistBase
    {
        public PlaylistWithDetail()
        {
            
        }
        public IEnumerable<TrackBase> Tracks { get; set; }
    }

    public class PlaylistEditTracksForm
    {
        public PlaylistEditTracksForm()
        {
            NowOnPlayList = new List<TrackBase>();
        }
        [Key]
        public int PlaylistId { get; set; }
        [StringLength(120)]
        public string Name { get; set; }

        public MultiSelectList playlistlist { get; set; }
        public IEnumerable<TrackBase> NowOnPlayList { get; set; }
        public int TracksCount { get; set; }
    }
    public class PlaylistEditTracks
    {
        public PlaylistEditTracks()
        {

        }
        [Key]
        public int playlistId { get; set; }
        public IEnumerable<int> TrackIds { get; set; }

    }
}
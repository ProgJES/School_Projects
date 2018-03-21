using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment9.Controllers
{
    public class AlbumBase : AlbumAdd
    {
        public int Id { get; set; }
        [Display(Name = "Alubm's primary genre")]
        public string Genre { get; set; }
    }
    public class AlbumWithDetail : AlbumBase
    {
        public AlbumWithDetail()
        {
            Artists = new List<ArtistBase>();
            Tracks = new List<TrackBase>();
        }
        public IEnumerable<ArtistBase> Artists { get; set; }
        public IEnumerable<TrackBase> Tracks { get; set; }
    }
    public class AlbumAdd
    {
        public AlbumAdd()
        {
            ReleaseDate = DateTime.Now;
        }

        [Required, StringLength(100)]
        [Display(Name = "Album name")]
        public string Name { get; set; }

        [Display(Name = "Release date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ReleaseDate { get; set; }

        // Get from Apple iTunes Preview, Amazon, or Wikipedia
        [Required, StringLength(200)]
        [Display(Name = "Album cover art")]
        public string UrlAlbum { get; set; }

        [Required]
        public int GenreId { get; set; }

        // User name who looks after the album
        public string Coordinator { get; set; }

        [DataType(DataType.MultilineText)]
        public string Depiction { get; set; }

        public int ArtistId { get; set; }
        /*We don't get number of artists and the tracks*/
        //public IEnumerable<int> ArtistIds { get; set; }
        //public IEnumerable<int> TrackIds { get; set; }
    }
    public class AlbumAddForm : AlbumAdd
    {
        public string ArtistName { get; set; }
        [Display(Name = "Album's primary genre")]
        public SelectList GenreList { get; set; }
        public MultiSelectList ArtistList { get; set; }
        public MultiSelectList TrackList { get; set; }

        [Display(Name = "URL to album photo")]
        public string UrlAl { get; }
       
    }
}
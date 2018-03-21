using Assignment8.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment8.Controllers
{
    public class AlbumBase : AlbumAdd
    {
        public int Id { get; set; }
    }
    public class AlbumWithDetail : AlbumBase
    {
        public AlbumWithDetail()
        {
            Artists = new List<ArtistBase>();
            Tracks = new List<TrackBase>();
        }
        public IEnumerable<string> ArtistNames { get; set; }
        public IEnumerable<ArtistBase> Artists { get; set; }
        public IEnumerable<TrackBase> Tracks { get; set; }
    }
    public class AlbumAddForm : AlbumAdd
    {

        public string ArtistName { get; set; }
        /*Select & Multi Select List*/
        [Display(Name = "Album's primary genre")]
        public SelectList GenreList { get; set; }
        public MultiSelectList ArtistList { get; set; }
        public MultiSelectList TrackList { get; set; }
    }
    public class AlbumAdd
    {
        public AlbumAdd()
        {
            ReleaseDate = DateTime.Now;
        }
        [Display(Name = "Album Name")]
        public string Name { get; set; }
        [Display(Name = "Release date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "URL to album image (cover art)")]
        public string UrlAlbum { get; set; }
        [Display(Name = "Album's primary genre")]
        public string Genre { get; set; }
        public string Coordinator { get; set; }
       
     
        /*Navigation property*/
        public int GenreId { get; set; }
        public IEnumerable<int> TrackIds { get; set; }
        public IEnumerable<int> ArtistIds { get; set; }  
    }
}
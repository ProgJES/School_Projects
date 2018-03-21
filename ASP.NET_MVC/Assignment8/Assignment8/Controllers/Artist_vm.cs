using Assignment8.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment8.Controllers
{
    public class ArtistBase : ArtistAdd
    {
        public int Id { get; set; }
       
    }
    public class ArtistWithDetail : ArtistBase
    {
        public ArtistWithDetail()
        {
            Albums = new List<AlbumBase>();
        }
        public IEnumerable<AlbumBase> Albums { get; set; }
    }
    /*ArtistAddForm*/
    public class ArtistAddForm : ArtistAdd
    {
        [Display(Name = "Artist's primary genre")]
        public SelectList GenreList { get; set; }
    }
    public class ArtistAdd
    {
        public ArtistAdd()
        {
            BirthOrStartDate = DateTime.Now;
        }
        [Display(Name = "Birth date, or start date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthOrStartDate { get; set; }
        [Display(Name = "Artist name or stage name")]
        public string Name { get; set; }
        public string Executive { get; set; }
        [Display(Name = "URL to artist photo")]
        public string UrlArtist { get; set; }
        [Display(Name = "If applicable, artist's birth name")]
        public string BirthName { get; set; }
        public string Genre { get; set; }

        public int AlbumsCount { get; set; }
        public int GenreId { get; set; }  
    }
}
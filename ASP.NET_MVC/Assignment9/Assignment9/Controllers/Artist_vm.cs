using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment9.Controllers
{
    public class ArtistBase : ArtistAdd
    {
        public int Id { get; set; }
        // User name who looks after this artist
        [Required, StringLength(200)]
        public string Executive { get; set; }
        [Display(Name = "Artist's primary genre")]
        public string Genre { get; set; }
    }

    public class ArtistWithDetail : ArtistBase
    {
        public ArtistWithDetail()
        {
            Albums = new List<AlbumBase>();
        }
        public IEnumerable<AlbumBase> Albums { get; set; }
    }

    public class ArtistAdd
    {
        public ArtistAdd()
        {
            BirthName = "";
            BirthOrStartDate = DateTime.Now.AddYears(-20);
        }
        // For an individual, can be birth name, or a stage/performer name
        // For a duo/band/group/orchestra, will typically be a stage/performer name
        [Required, StringLength(100)]
        [Display(Name = "Artist's name or stage name")]
        public string Name { get; set; }

        // For an individual, a birth name
        [StringLength(100)]
        [Display(Name = "If applicable, artist's birth name")]
        public string BirthName { get; set; }

        // For an individual, a birth date
        // For all others, can be the date the artist started working together
        [Display(Name = "Birth date, or start date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthOrStartDate { get; set; }

        // Get from Apple iTunes Preview, Amazon, or Wikipedia
        [Required, StringLength(200)]
        [Display(Name = "Artist's photo")]
        public string UrlArtist { get; set; }

        [Required]
        public int GenreId { get; set; }

        [DataType(DataType.MultilineText)]
        public string Portrayal { get; set; }
    }

    public class ArtistAddForm : ArtistAdd
    {
        public ArtistAddForm()
        {

        }
        [Display(Name = "Artist's primary genre")]
        public SelectList GenreList { get; set; }
        [Display(Name ="URL to artist photo")]
        public string Url { get; }
    }

    public class ArtistWithContentStringIds : ArtistWithDetail
    {
        public ArtistWithContentStringIds()
        {
            MediaItems = new List<MediaContent>();
        }
        public IEnumerable<MediaContent> MediaItems { get; set; }
    }
}

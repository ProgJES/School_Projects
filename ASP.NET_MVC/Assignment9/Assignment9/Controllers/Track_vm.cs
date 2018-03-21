using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment9.Controllers
{
    public class TrackBase : TrackAdd
    {
        public int Id { get; set; }
       
        public string Genre { get; set; }
    }

    public class TrackWithDetail : TrackBase
    {
        public TrackWithDetail()
        {
            Albums = new List<AlbumBase>();
        }
        public IEnumerable<AlbumBase> Albums { get; set; }

        [Display(Name = "Sample clip")]
        public string AudioName
        {
            get
            {
                return $"/audio/{Id}";
            }
        }
    }


    public class TrackAudio
    {
        public int Id { get; set; }
        public string AudioContentType { get; set; }
        public byte [] Audio { get; set; }
    }


    public class TrackAdd
    {
        public TrackAdd()
        {

        }

        [Required, StringLength(200)]
        public string Name { get; set; }

        // Simple comma-separated string of all the track's composers
        [Required, StringLength(500)]
        public string Composers { get; set; }

        public string Clerk { get; set; }     

        [Required]
        public int GenreId { get; set; }

        [Required]
        public HttpPostedFileBase AudioUpload { get; set; }
    }
    public class TrackAddForm
    {
        public TrackAddForm()
        {

        }

        [Required, StringLength(200)]
        public string Name { get; set; }

        // Simple comma-separated string of all the track's composers
        [Required, StringLength(500)]
        public string Composers { get; set; }

        [Required]
        [Display(Name = "Track genre")]
        public int GenreId { get; set; }

        [Required]
        [Display(Name = "Sample clip")]
        [DataType(DataType.Upload)]
        public string AudioUpload { get; set; }
 
        [Display(Name = "Track's primary genre")]
        public SelectList GenreList { get; set; }

        public string AlbumName { get; set; }
    }
    public class TrackEditForm
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Sample clip")]
        [DataType(DataType.Upload)]
        public string AudioUpload { get; set; }

        public string TrackName { get; set; }
    }
    public class TrackEdit
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Sample clip")]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase AudioUpload { get; set; }
    }
}
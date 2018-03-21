using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment9.Controllers
{
    public class MediaItemBase
    {
        public int Id { get; set; }
        [Display(Name = "Added on date/time")]
        public DateTime TimeStamp { get; set; }
        [Required, StringLength(100)]
        [Display(Name = "Unique identifier")]
        public string StringId { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Descriptive caption")]
        public string Caption { get; set; }
    }
    public class MediaContent : MediaItemBase
    { 
        public string ContentType { get; set; }
        public  byte [] Content { get; set; }
    }
    public class MediaItemAddForm
    {
        public int ArtistId { get; set; }


        [Display(Name = "Artist information")]
        public string ArtistInfo { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Descriptive caption")]
        public string Caption { get; set; }

        [Required]
        [Display(Name = "Media Item")]
        [DataType(DataType.Upload)]
        public string ContentUpload { get; set; }

        public string ArtistName { get; set; }
    }
    public class MediaItemAdd
    {
        public int ArtistId { get; set; }
        [Required]
        public string Caption { get; set; }
        [Required]
        public HttpPostedFileBase ContentUpload { get; set; }
    }
}
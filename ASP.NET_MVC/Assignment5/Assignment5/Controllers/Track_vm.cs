using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment5.Controllers
{
    public class TrackBase : TrackAdd
    {
        [Key]
        public int TrackId { get; set; }

        
    }
    public class TrackAdd
    {
        public TrackAdd()
        {

        }
        [Required]
        [StringLength(200)]
        [Display(Name = "Track name")]
        public string Name { get; set; }

        [StringLength(220)]
        [Required]
        public string Composer { get; set; }

        [Display(Name = "Length (ms)")]
        public int Milliseconds { get; set; }

        [Column(TypeName = "numeric")]
        [Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }

        [Range(1, Int32.MaxValue)]
        public int AlbumId { get; set; }

        [Range(1, Int32.MaxValue)]
        public int MediaTypeId { get; set; }
        

    }
    public class TrackAddForm : TrackAdd
    {
        public TrackAddForm()
        {

        }
        [Display(Name = ("Album"))]
        public SelectList AlbumList { get; set; }
        public SelectList MediaTypeList { get; set; }
    }
}
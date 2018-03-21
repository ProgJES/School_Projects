using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment5.Controllers
{
    public class TrackWithDetail : TrackBase
    {
        public TrackWithDetail()
        {

        }
        public string AlbumArtistName { get; set; }
        public string AlbumTitle { get; set; }
        public MediaTypeBase MediaType { get; set; }
    }
}
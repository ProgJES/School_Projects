using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment8.Controllers
{
    public class GenreBase
    {
        public GenreBase()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
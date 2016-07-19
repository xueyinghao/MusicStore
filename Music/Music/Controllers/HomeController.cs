using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Music.Models;

namespace Music.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var genres = new List<Genre>
            {
                new Genre{Name="Jazz"},
                new Genre{Name="Disco"},
                new Genre{Name="Rock"}
            };
            return View(genres);
        }

        public ActionResult Detail(int id)
        {
            var album = new Album { Title = "Album" + id };
            return View(album);
        }

        public ActionResult Browse(string genre)
        {
            var genreModel = new Genre { Name = genre };
            return View(genreModel);
        }
    }
}
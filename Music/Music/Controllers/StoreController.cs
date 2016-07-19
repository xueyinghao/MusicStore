using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Music.Models;

namespace Music.Controllers
{
    public class StoreController : Controller
    {
        MusicEntities storeDB = new MusicEntities();
        // GET: Store
        public ActionResult Index()
        {
            var genres = storeDB.Genres.ToList();
            return this.View(genres);
        }
        public ActionResult Browse(string genre)
        {
            var example = storeDB.Genres.Include("Albums").Single(c => c.Name == genre);
            return this.View(example);
        }
        public ActionResult Detail(string Title)
        {
            var res = storeDB.Albums.Single(c => c.Title == Title);
            return View(res);
        }

        public ActionResult Del(int id)
        {
            var res1 = storeDB.Albums.Find(id);
            return View(res1);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Music.Models;

namespace Music.Controllers
{
    public class StoreManagerController : Controller
    {
        MusicEntities storeDB = new MusicEntities();
        // GET: StoreManager
        public ActionResult Index()
        {
            var albums = storeDB.Albums.Include("Genre").Include("Artist");
            return View(albums.ToList());
        }
        public ActionResult Edit(int id)
        {
            var example = storeDB.Albums.Find(id);
            return View(example);
        }
        [HttpPost]
        public ActionResult Edit(int id,FormCollection form)
        {
            try
            {
                Album album = storeDB.Albums.Find(id);
                if (this.TryUpdateModel<Music.Models.Album>(album))
                {
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch 
            {
                return View();
            }
        }
    }
}
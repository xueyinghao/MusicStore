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
        //新增数据
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name");
            ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                storeDB.Albums.Add(album);
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name", album.ArtistId);
            return View(album);
        }


        //修改数据
        public ActionResult Edit(int id)
        {
            Album album = storeDB.Albums.Find(id);
            return View(album);
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
                //ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name", album.ArtistId);
                //ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name", album.GenreId);
                return View();
            }
            catch 
            {
                return View();
            }
        }

        //详细信息
        public ActionResult Details(int id)
        {
            Album album = storeDB.Albums.Find(id);
            return View(album);
        }

        //删除
        public ActionResult Delete(int id)
        {
            Album album = storeDB.Albums.Find(id);
            return View(album);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Album album = storeDB.Albums.Find(id);
                storeDB.Albums.Remove(album);
                return RedirectToAction("Index");
            }
            catch 
            {
                return View();
            }
        }
      
    }
}
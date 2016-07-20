using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Music.Models;
using System.Data.Entity;

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
            ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name", album.ArtistId);
            ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name", album.GenreId);
            return View(album);
        }

        //这里使用了FormCollection来传递表单数据,使用模型传递的还没搞清楚
        //[HttpPost]
        //public ActionResult Edit(int id,FormCollection form)
        //{
        //    try
        //    {
        //        Album album = storeDB.Albums.Find(id);
        //        if (this.TryUpdateModel<Music.Models.Album>(album))
        //        {
        //            album.Title = form["Title"];
        //            album.Price =decimal.Parse(form["Price"]);
        //            storeDB.Entry(album).State = System.Data.Entity.EntityState.Modified;
        //            storeDB.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        //状态未改变则继续显示之前的数据
        //        ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name", album.ArtistId);
        //        ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name", album.GenreId);
        //        return View();
        //    }
        //    catch 
        //    {
        //        return View();
        //    }
        //}

        //------------------------------------------------------------------------------------------------------------我是一条分割线

        //貌似这里就是使用模型进行绑定处理的方法
        //测试显示是没问题的,还要在继续研究研究,还是不懂耶
        [HttpPost]
        public ActionResult Edit(Album album)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    storeDB.Entry(album).State = System.Data.Entity.EntityState.Modified;
                    storeDB.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.ArtistId = new SelectList(storeDB.Artists, "ArtistId", "Name", album.ArtistId);
                ViewBag.GenreId = new SelectList(storeDB.Genres, "GenreId", "Name", album.GenreId);
                return View(album);
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
        //依然使用FormCollection来处理表单提交的数据
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfired(int id)
        {
            try
            {
                Album album = storeDB.Albums.Find(id);
                //storeDB.Entry(album).State = EntityState.Deleted;
                storeDB.Albums.Remove(album);
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
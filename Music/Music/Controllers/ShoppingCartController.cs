using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Music.Models;
using Music.ViewModels;

namespace Music.Controllers
{
    public class ShoppingCartController : Controller
    {
        MusicEntities storeDB = new MusicEntities();
        // GET: ShoppingCart
        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            return View(viewModel);
        }
        public ActionResult AddToCart(int id)
        {
            var addedAlbum = storeDB.Albums.Single(album => album.AlbumId == id);
            var cart = ShoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(addedAlbum);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            string albumName = storeDB.Carts.Single(item => item.RecordId == id).Album.Title;
            int itemCount = cart.RemoveFromCart(id);
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(albumName) + "has been removed from your shopping cart",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);
            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }


    }
}
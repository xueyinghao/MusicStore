using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Music.Models
{
    public partial class ShoppingCart
    {
        MusicEntities storeDB = new MusicEntities();
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        public static ShoppingCart GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }

        public static ShoppingCart GetCart(Controllers controller)
        {
            return GetCart(controller.HttpContext);
        }
        public void AddToCart(Album album)
        {
            var cartItem = storeDB.Cars.SingleOrDefault(c=>c.CarId==ShoppingCartId&&c.AlbumId==album.AlbumId);
            if (cartItem == null)
            {
                cartItem = new Car
                {
                    AlbumId = album.AlbumId,
                    CarId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                storeDB.Cars.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
            }
            storeDB.SaveChanges();

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Music.Models;
namespace Music.ViewModels
{
    public class ShoppingCartViewModel
    {
        
        public int CartId { get; set; }
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
    public class Cart
    {
        public List<CartItem> Items { get; set; }

        public decimal TotalPrice()
        {
            return Items.Sum(item => item.Price * item.Quantity);
        }
    }
}
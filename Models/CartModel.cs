using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class CartModel
    {
        public Product Product { get; set; }
        public Brand Brand { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; }
        public Order Order { get; set; }
    }
}
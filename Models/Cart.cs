using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class Cart
    {
        public Cart(int id)
        {
            Id = id;
        }

        public int Id { set; get; }
        public string Name { set; get; }
        public string Avatar { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
         public double ThanhTien { get { return Quantity* Price; } }


      
    }
}
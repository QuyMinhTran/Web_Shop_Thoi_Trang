using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class ProductController : Controller
    {
        webbanhangEntities db = new webbanhangEntities();
        // GET: Product
        public ActionResult Detail(int id)
        {
            var prt = db.Products.Where(n => n.Id == id).FirstOrDefault();
            return View(prt);
        }

        [HttpPost]
        public ActionResult Search(string searchTerm)
        {
            var products = db.Products.Where(p => p.Name.Contains(searchTerm)).ToList();

            return View(products);
        }

        //[HttpPost]
        //public ActionResult Filter(decimal minPrice, decimal maxPrice)
        //{
        //    var pro = db.Products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
        //    return View(pro);
        //}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
namespace WebBanHang.Controllers
{
    public class BrandController : Controller
    {
        webbanhangEntities db = new webbanhangEntities();
        // GET: Brand
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProductBrand(int ID)
        {
            var lstp = db.Products.Where(n => n.BrandID == ID).ToList();
            return View(lstp);
        }
        
    }
}
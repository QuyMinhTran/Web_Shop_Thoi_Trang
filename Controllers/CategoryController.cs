using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class CategoryController : Controller
    {
        webbanhangEntities db = new webbanhangEntities();
        // GET: Category
        public ActionResult Index()
        {
            var lstCategory = db.Categories.ToList();
            return View(lstCategory);
        }
        public ActionResult ProductCategory(int Id )
        {
            var lstp = db.Products.Where(n => n.CategoryId == Id).ToList();
            return View(lstp);
        }
    }
}
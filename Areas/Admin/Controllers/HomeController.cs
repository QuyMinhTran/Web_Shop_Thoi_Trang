using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
namespace WebBanHang.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        webbanhangEntities db = new webbanhangEntities();
        // GET: Admin/Home
        public ActionResult Index()
        {
            if(Session["idUser"] != null)
            {
                var lstProduct = db.Products.ToList();
            }
            else
            {
                return View("Login");
            }

            return RedirectToAction("Index");
        }
    }
}
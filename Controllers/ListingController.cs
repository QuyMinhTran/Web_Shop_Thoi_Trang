using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHang.Controllers
{
    public class ListingController : Controller
    {
        // GET: Listing
        public ActionResult Large()
        {
            return View();
        }
        public ActionResult Grid()
        {
            return View();
        }
    }
}
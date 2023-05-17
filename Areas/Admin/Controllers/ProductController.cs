using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;
namespace WebBanHang.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        webbanhangEntities db = new webbanhangEntities();
        // GET: Admin/Product
        public ActionResult Index()
        {

            return View(db.Products.ToList());
        }

        //public ActionResult Index(string currentFilter, string SearchString, int page)
        //{
        //    var lstpr = new List<Product>();
        //    if(SearchString != null)
        //    {
        //        page = 1;
        //    }
        //    else
        //    {
        //        SearchString = currentFilter;

        //    }
        //    if(!string.IsNullOrEmpty(SearchString))
        //    {
        //        lstpr = db.Products.Where(n => n.Name.Contains(SearchString)).ToList();

        //    }
        //    else
        //    {
        //        lstpr = db.Products.ToList();
        //    }
        //    ViewBag.CurrentFilter = SearchString;
        //    int pageSize = 4;
        //    int pageNumber = (page - 1) * pageSize;
        //    lstpr = lstpr.OrderByDescending(n => n.Id).ToList();
        //    return View(lstpr.ToPagedList(pageNumber, pageSize));
        //}

        public ActionResult Details(int id)
        {
            return View(db.Products.Where(x => x.Id == id).FirstOrDefault()); ;
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {


            return View(db.Products.Where(x => x.Id == id).FirstOrDefault()); ;

        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            try
            {
                // TODO: Add update logic here

                db.Entry(product).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {


            return View(db.Products.Where(x => x.Id == id).FirstOrDefault()); ;

        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Product product)
        {
            try
            {
                // TODO: Add delete logic here

                product = db.Products.Where(x => x.Id == id).FirstOrDefault();
                db.Products.Remove(product);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Search(string searchTerm)
        {
            var products = db.Products.Where(p => p.Name.Contains(searchTerm)).ToList();

            return View(products);
        }
    }
}
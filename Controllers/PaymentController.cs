using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.Models;

namespace WebBanHang.Controllers
{
    public class PaymentController : Controller
    {
        webbanhangEntities db = new webbanhangEntities();
        // GET: Payment
        public ActionResult Index()
        {
            if (Session["idUser"] == null) 
            { 
                return RedirectToAction("Login", "Home");
            }
            else
            {
                //lấy thông tin từ giỏ hàng 
                var lstCart = (List<CartModel> )Session["Cart"];
                //gán dữ liệu cho order 
                Order objOrder = new Order();
                objOrder.Name = "DonHang-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                objOrder.UserId= int.Parse(Session["idUser"].ToString());
                objOrder.CreatedOnUtc = DateTime.Now;
                objOrder.Status = 1;
                db.Orders.Add(objOrder);
                //Lưu thông tin dữ liệu vào bảng order 
                db.SaveChanges();

                //lấy orderId mới vừa tạo để lưu vào bảng orderDetail
                int intOrderId = objOrder.Id;
                List<OrderDetail> lstOrderDetails = new List<OrderDetail>();
                foreach (var item in lstCart)
                {
                    OrderDetail obj = new OrderDetail();
                    obj.Quantity = item.Quantity;
                    obj.OrderId = intOrderId;
                    obj.ProductId = item.Product.Id;
                    lstOrderDetails.Add(obj);
                   
                }
                db.OrderDetails.AddRange(lstOrderDetails);
                db.SaveChanges();
            }    
            return View();
        }
    }
}
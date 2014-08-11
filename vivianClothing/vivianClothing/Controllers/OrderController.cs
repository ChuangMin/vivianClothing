using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vivianClothing.Models;

namespace vivianClothing.Controllers
{
    [Authorize]
    public class OrderController : BaseController
    {
        //
        // GET: /Order/
        //顯示完成訂單的表單頁面
        public ActionResult Complete()
        {
            return View();
        }
        //將病單資料與購物車資料寫入資料庫
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Complete(OrderHeader form)
        {
            var member = db.Member.Where(p => p.Email == User.Identity.Name).FirstOrDefault();

            if (member ==null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (Carts.Count == 0 )
            {
                return RedirectToAction("Index", "Cart");
            }

            //將訂單資料與購物車資料寫入資料庫
            OrderHeader oh = new OrderHeader()
            {
                Member = member,
                ContactName = form.ContactName,
                ContactAddress = form.ContactPhoneNo,
                ContactPhoneNo = form.ContactPhoneNo,
                BuyOn = DateTime.Now,
                memo = form.memo,
                OrderDetailItems = new List<OrderDetail>()
            };

            int total_price = 0;
            foreach (var item in this.Carts)
            {
                var product = db.Products.Find(item.Product.Id);
                if (product==null)
                {
                    return RedirectToAction("Index", "Home");
                }

                total_price += item.Product.Price * item.Amount;
                oh.OrderDetailItems.Add(new OrderDetail() { 
                    Product = product, 
                    Price = product.Price
                    //Amount = item.Amount   //TODO: different with book page 407
                });   //,  

            }
            
            oh.TotalPrice = total_price ;

            db.Orders.Add(oh);
            db.SaveChanges();

            // 訂單完成後必須清空現有購物車資料
            this.Carts.Clear();
            return RedirectToAction("Index","Home");
        }

    }
}

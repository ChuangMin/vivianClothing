using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace vivianClothing.Controllers
{
    public class CartController : Controller
    {
        //
        // GET: /Cart/

        //加入產品項目到購物車，如果沒有傳入Amount參數哲預設購買數量為1
        [HttpPost] // 用ajax 呼叫這個action
        public ActionResult AddToCart(int ProductId, int Amount = 1)
        {
            return View();
        }

            
        //顯示目前的購物車項目
        public ActionResult Index()
        {
            return View();
        }
        //移除購物車
        [HttpPost] // 用ajax 呼叫這個action
        public ActionResult Remove(int ProductId)
        {
            return View();
        }

        //更新購物車中特定項目的購買數量
        [HttpPost] // 用ajax 呼叫這個action
        public ActionResult UpdateAmount(int ProductId, int NewAmount )
        {
            return View();
        }
    }
}

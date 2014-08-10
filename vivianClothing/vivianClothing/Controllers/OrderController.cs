using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vivianClothing.Models;

namespace vivianClothing.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        //顯示完成訂單的表單頁面
        public ActionResult Compelete()
        {
            return View();
        }
        //將病單資料與購物車資料寫入資料庫
        [HttpPost]
        public ActionResult Complete(FormCollection form)
        {
            //TODO: 將訂單資料與購物車資料寫入資料庫

            //TODO: 訂單完成後必須清空現有購物車資料

            return RedirectToAction("Index","Home");
        }

    }
}

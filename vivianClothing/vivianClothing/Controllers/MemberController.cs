using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using vivianClothing.Models;

namespace vivianClothing.Controllers
{
    public class MemberController : Controller
    {
        //
        // GET: /Member/
        //會員註冊畫面
        public ActionResult Register()
        {
            return View();
        }
       
        
        // 寫入會員資料        
        [HttpPost]
        public ActionResult Register([Bind(Exclude="RigisterOn,AuthCode")] Member Member)
        {
            return View();
        }
        
        
        // 顯示會員登入頁面
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        
        //執行會員登入
        [HttpPost]
        public ActionResult Login(string email,string password, string returnUrl)
        {
            if (ValidateUser(email, password))
            {
                FormsAuthentication.SetAuthCookie(email, false);

                if (String.IsNullOrEmpty(returnUrl))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Redirect(returnUrl);
                }
            }
            ModelState.AddModelError("", "您輸入的帳號密碼錯誤");
            return View();
        }

        public bool ValidateUser(string email, string password)
        {
            throw new NotImplementedException();
        }

        //執行會員登出
        public ActionResult Logout()
        { 
            //清除表單驗證的cookie
            FormsAuthentication.SignOut();
            //清除所有曾經寫入過的session 資料
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using vivianClothing.Models;
using System.Net.Mail;
namespace vivianClothing.Controllers
{
    public class MemberController : BaseController
    {
        
        // GET: /Member/
        //會員註冊畫面
        public ActionResult Register()
        {
            return View();
        }

        private string pwSalt = "A1rySq1oPe2Mh784QQwGjRAfkdPpDa90J0i";
        // 寫入會員資料        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Exclude="RigisterOn,AuthCode")] Member member)
        {
            var chk_member = db.Member.Where(p => p.Email == member.Email).FirstOrDefault();

            if (chk_member != null)
            {
                ModelState.AddModelError("Email", "已經有人註冊了!");
            }

            if (ModelState.IsValid)
            {
                member.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(pwSalt + member.Password, "SHA1");

                member.RegisterOn = DateTime.Now.ToString();

                member.AutoCode = Guid.NewGuid().ToString();

                db.Member.Add(member);
                db.SaveChanges();

                SendAuthCodeToMember(member);

                return RedirectToAction("Index", "Home");

            }
            else
            {
                return View();
            }
            
        }

        private void SendAuthCodeToMember(Member member)
        {
            string mailBody = System.IO.File.ReadAllText(Server.MapPath("~/App_Data/MemberRegisterEMailTemplate.htm"));

            mailBody = mailBody.Replace("{{Name}}", member.Name);
            mailBody = mailBody.Replace("{{RegisterOn}}", member.RegisterOn.ToString()); //TODO: different with book page 410

            var auth_url = new UriBuilder(Request.Url)
            {
                Path = Url.Action("ValidateRegister", new { id = member.AutoCode }),
                Query = ""
            };
            mailBody = mailBody.Replace("{{AUTH_URL}}",auth_url.ToString());

            try
            {
                SmtpClient SmtpSever = new SmtpClient("smtp.gmail.com");
                SmtpSever.Port = 587;
                SmtpSever.Credentials = new System.Net.NetworkCredential("irresolution@boian.tw", "cj;61tj;41aup31");
                SmtpSever.EnableSsl = true;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("irresolution@boian.tw");
                mail.To.Add(member.Email);
                mail.Subject = "[Vivian 小舖] 會員認證信";
                mail.Body = mailBody;
                mail.IsBodyHtml = true;
                //TODO: record send mail success
            }
            catch (Exception ex)
            {
                //TODO: record send mail fail
                throw ex;
            }

            //throw new NotImplementedException();
        }
        
        
        // 顯示會員登入頁面
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        
        //執行會員登入
        [HttpPost]
        [ValidateAntiForgeryToken]
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
   
            return View();
        }

        public bool ValidateUser(string email, string password)
        {
            var hash_pw = FormsAuthentication.HashPasswordForStoringInConfigFile(pwSalt + password, "SHA1");

            var member = (from p in db.Member 
                           where p.Email == email && p.Password == hash_pw 
                           select p).FirstOrDefault();

            if (member!=null)
            {
                if (member.AutoCode==null)
                {
                    return true;
                }
                else
                {
                    ModelState.AddModelError("", "您尚未通過會員認證");
                    return false;
                }
            }
            else
            {
                ModelState.AddModelError("", "您輸入的帳號或密碼錯誤 ");
                return false;
            }

            //return (member != null);// 不為null 代表會員帳號密碼正確。
            //throw new NotImplementedException();
        }

        public ActionResult ValidateRegister(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return HttpNotFound();
            }

            var member = db.Member.Where(p => p.AutoCode == id).FirstOrDefault();

            if (member != null)
            {
                TempData["LastTempMessage"] = "會員認證成功，您現在可以登入網站了";
                member.AutoCode = null;
                db.SaveChanges();
            }
            else
            {
                TempData["LastTempMessage"] = "查無此會員驗證碼，您可能已經驗證過了";
            }

            return RedirectToAction("Login", "Member");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckDup(string email)
        {
            var member = db.Member.Where(p => p.Email == email).FirstOrDefault();

            if (member!=null)
            {
                return Json("您輸入的Email已經有人註冊過了");
            }
            else
            {
                return Json(true);
            }  
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

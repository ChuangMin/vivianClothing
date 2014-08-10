using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace vivianClothing.Controllers
{
    public class HomeController1 : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Upload()
        {
           // ViewBag.Message = "Your upload page.";
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public void IMGUpload()
        {
            foreach (string file in Request.Files)
            {
                var postedFile = Request.Files[file];
                postedFile.SaveAs(Server.MapPath("~/UploadedFiles/") + postedFile.FileName);  //??Path.GetFileName(postedFile.FileName));

            }
        }

    }
}

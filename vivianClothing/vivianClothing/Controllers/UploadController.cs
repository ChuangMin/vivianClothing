using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace vivianClothing.Controllers
{
    public class UploadController : Controller
    {
        //
        // GET: /Upload/

        public ActionResult Index()
        {
            ViewBag.Message = "Your upload page.";
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public void Upload()
        {
            foreach (string file in Request.Files)
            {
                var postedFile = Request.Files[file];
                postedFile.SaveAs(Server.MapPath("~/UploadedFiles/") + postedFile.FileName);  //??Path.GetFileName(postedFile.FileName));

            }
        }

    }

}

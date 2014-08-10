using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vivianClothing.Views.Gusetbook;
using vivianClothing.Models;

namespace vivianClothing.Controllers
{
    public class imgController : Controller
    {
        private MvcimgContext db = new MvcimgContext();

        //
        // GET: /img/

        public ActionResult Index()
        {
            return View(db.imgs.ToList());
        }

        //
        // GET: /img/Details/5

        public ActionResult Details(int id = 0)
        {
            img img = db.imgs.Find(id);
            if (img == null)
            {
                return HttpNotFound();
            }
            return View(img);
        }

        //
        // GET: /img/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /img/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(img img)
        {
            if (ModelState.IsValid)
            {
                db.imgs.Add(img);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //foreach (string file in Request.Files)
            //{
            //    var postedFile = Request.Files[file];
            //    postedFile.SaveAs(Server.MapPath("~/UploadedFiles/") + postedFile.FileName);  //??Path.GetFileName(postedFile.FileName));

            //}


            return View(img);
        }

        //
        // GET: /img/Edit/5

        public ActionResult Edit(int id = 0)
        {
            img img = db.imgs.Find(id);
            if (img == null)
            {
                return HttpNotFound();
            }
            return View(img);
        }

        //
        // POST: /img/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(img img)
        {
            if (ModelState.IsValid)
            {
                db.Entry(img).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(img);
        }

        //
        // GET: /img/Delete/5

        public ActionResult Delete(int id = 0)
        {
            img img = db.imgs.Find(id);
            if (img == null)
            {
                return HttpNotFound();
            }
            return View(img);
        }

        //
        // POST: /img/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            img img = db.imgs.Find(id);
            db.imgs.Remove(img);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
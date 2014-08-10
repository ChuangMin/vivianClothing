using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vivianClothing.Models;

namespace vivianClothing.Controllers
{
    public class GusetbookController : Controller
    {
        private MvcguestbookContext db = new MvcguestbookContext();

        //
        // GET: /Gusetbook/

        public ActionResult Index()
        {
            return View(db.GuestBooks.ToList());
        }

        //
        // GET: /Gusetbook/Details/5

        public ActionResult Details(int id = 0)
        {
            GuestBook guestbook = db.GuestBooks.Find(id);
            if (guestbook == null)
            {
                return HttpNotFound();
            }
            return View(guestbook);
        }

        //
        // GET: /Gusetbook/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Gusetbook/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GuestBook guestbook)
        {
            if (ModelState.IsValid)
            {
                db.GuestBooks.Add(guestbook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(guestbook);
        }

        //
        // GET: /Gusetbook/Edit/5

        public ActionResult Edit(int id = 0)
        {
            GuestBook guestbook = db.GuestBooks.Find(id);
            if (guestbook == null)
            {
                return HttpNotFound();
            }
            return View(guestbook);
        }

        //
        // POST: /Gusetbook/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GuestBook guestbook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guestbook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guestbook);
        }

        //
        // GET: /Gusetbook/Delete/5

        public ActionResult Delete(int id = 0)
        {
            GuestBook guestbook = db.GuestBooks.Find(id);
            if (guestbook == null)
            {
                return HttpNotFound();
            }
            return View(guestbook);
        }

        //
        // POST: /Gusetbook/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GuestBook guestbook = db.GuestBooks.Find(id);
            db.GuestBooks.Remove(guestbook);
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
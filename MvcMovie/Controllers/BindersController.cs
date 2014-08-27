using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcMovie.DAL;

namespace MvcMovie.Controllers
{
    public class BindersController : Controller
    {
        private MovieDBContext db = new MovieDBContext();

        // GET: Binders
        public ActionResult Index()
        {
            return View(db.Binders.ToList());
        }

        // GET: Binders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Binder binder = db.Binders.Find(id);
            if (binder == null)
            {
                return HttpNotFound();
            }
            return View(binder);
        }

        // GET: Binders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Binders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BinderNumber,Label")] Binder binder)
        {
            if (ModelState.IsValid)
            {
                db.Binders.Add(binder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(binder);
        }

        // GET: Binders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Binder binder = db.Binders.Find(id);
            if (binder == null)
            {
                return HttpNotFound();
            }
            return View(binder);
        }

        // POST: Binders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BinderNumber,Label")] Binder binder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(binder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(binder);
        }

        // GET: Binders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Binder binder = db.Binders.Find(id);
            if (binder == null)
            {
                return HttpNotFound();
            }
            return View(binder);
        }

        // POST: Binders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Binder binder = db.Binders.Find(id);
            db.Binders.Remove(binder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

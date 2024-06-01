using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prodavnica.Models;

namespace Prodavnica.Controllers
{
    public class KategorijeController : Controller
    {
        private Model1 db = new Model1();

        // GET: Kategorije
        public ActionResult Index()
        {
            return View(db.kategorijes.ToList());
        }

        // GET: Kategorije/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kategorije kategorije = db.kategorijes.Find(id);
            if (kategorije == null)
            {
                return HttpNotFound();
            }
            return View(kategorije);
        }

        // GET: Kategorije/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kategorije/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,kategorija")] kategorije kategorije)
        {
            if (ModelState.IsValid)
            {
                db.kategorijes.Add(kategorije);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kategorije);
        }

        // GET: Kategorije/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kategorije kategorije = db.kategorijes.Find(id);
            if (kategorije == null)
            {
                return HttpNotFound();
            }
            return View(kategorije);
        }

        // POST: Kategorije/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,kategorija")] kategorije kategorije)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kategorije).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategorije);
        }

        // GET: Kategorije/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kategorije kategorije = db.kategorijes.Find(id);
            if (kategorije == null)
            {
                return HttpNotFound();
            }
            return View(kategorije);
        }

        // POST: Kategorije/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            kategorije kategorije = db.kategorijes.Find(id);
            db.kategorijes.Remove(kategorije);
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

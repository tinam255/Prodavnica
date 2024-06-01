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
    public class DobavljaciController : Controller
    {
        private Model1 db = new Model1();

        // GET: Dobavljaci
        public ActionResult Index()
        {
            return View(db.dobavljacis.ToList());
        }

        // GET: Dobavljaci/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dobavljaci dobavljaci = db.dobavljacis.Find(id);
            if (dobavljaci == null)
            {
                return HttpNotFound();
            }
            return View(dobavljaci);
        }

        // GET: Dobavljaci/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dobavljaci/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,dobavljac")] dobavljaci dobavljaci)
        {
            if (ModelState.IsValid)
            {
                db.dobavljacis.Add(dobavljaci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dobavljaci);
        }

        // GET: Dobavljaci/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dobavljaci dobavljaci = db.dobavljacis.Find(id);
            if (dobavljaci == null)
            {
                return HttpNotFound();
            }
            return View(dobavljaci);
        }

        // POST: Dobavljaci/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,dobavljac")] dobavljaci dobavljaci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dobavljaci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dobavljaci);
        }

        // GET: Dobavljaci/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dobavljaci dobavljaci = db.dobavljacis.Find(id);
            if (dobavljaci == null)
            {
                return HttpNotFound();
            }
            return View(dobavljaci);
        }

        // POST: Dobavljaci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dobavljaci dobavljaci = db.dobavljacis.Find(id);
            db.dobavljacis.Remove(dobavljaci);
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

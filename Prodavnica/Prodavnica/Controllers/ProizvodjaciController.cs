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
    public class ProizvodjaciController : Controller
    {
        private Model1 db = new Model1();

        // GET: Proizvodjaci
        public ActionResult Index()
        {
            return View(db.proizvodjacis.ToList());
        }

        // GET: Proizvodjaci/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proizvodjaci proizvodjaci = db.proizvodjacis.Find(id);
            if (proizvodjaci == null)
            {
                return HttpNotFound();
            }
            return View(proizvodjaci);
        }

        // GET: Proizvodjaci/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proizvodjaci/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,proizvodjac")] proizvodjaci proizvodjaci)
        {
            if (ModelState.IsValid)
            {
                db.proizvodjacis.Add(proizvodjaci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(proizvodjaci);
        }

        // GET: Proizvodjaci/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proizvodjaci proizvodjaci = db.proizvodjacis.Find(id);
            if (proizvodjaci == null)
            {
                return HttpNotFound();
            }
            return View(proizvodjaci);
        }

        // POST: Proizvodjaci/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,proizvodjac")] proizvodjaci proizvodjaci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proizvodjaci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(proizvodjaci);
        }

        // GET: Proizvodjaci/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proizvodjaci proizvodjaci = db.proizvodjacis.Find(id);
            if (proizvodjaci == null)
            {
                return HttpNotFound();
            }
            return View(proizvodjaci);
        }

        // POST: Proizvodjaci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            proizvodjaci proizvodjaci = db.proizvodjacis.Find(id);
            db.proizvodjacis.Remove(proizvodjaci);
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

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
    public class ProizvodiController : Controller
    {
        private Model1 db = new Model1();

        // GET: Proizvodi
        public ActionResult Index()
        {
            var proizvodis = db.proizvodis.Include(p => p.dobavljaci).Include(p => p.kategorije).Include(p => p.proizvodjaci);
            return View(proizvodis.ToList());
        }

        // GET: Proizvodi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proizvodi proizvodi = db.proizvodis.Find(id);
            if (proizvodi == null)
            {
                return HttpNotFound();
            }
            return View(proizvodi);
        }

        // GET: Proizvodi/Create
        public ActionResult Create()
        {
            ViewBag.dob_id = new SelectList(db.dobavljacis, "id", "dobavljac");
            ViewBag.kat_id = new SelectList(db.kategorijes, "id", "kategorija");
            ViewBag.pr_id = new SelectList(db.proizvodjacis, "id", "proizvodjac");
            return View();
        }

        // POST: Proizvodi/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,naziv,kat_id,dob_id,pr_id,cena")] proizvodi proizvodi)
        {
            if (ModelState.IsValid)
            {
                db.proizvodis.Add(proizvodi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dob_id = new SelectList(db.dobavljacis, "id", "dobavljac", proizvodi.dob_id);
            ViewBag.kat_id = new SelectList(db.kategorijes, "id", "kategorija", proizvodi.kat_id);
            ViewBag.pr_id = new SelectList(db.proizvodjacis, "id", "proizvodjac", proizvodi.pr_id);
            return View(proizvodi);
        }

        // GET: Proizvodi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proizvodi proizvodi = db.proizvodis.Find(id);
            if (proizvodi == null)
            {
                return HttpNotFound();
            }
            ViewBag.dob_id = new SelectList(db.dobavljacis, "id", "dobavljac", proizvodi.dob_id);
            ViewBag.kat_id = new SelectList(db.kategorijes, "id", "kategorija", proizvodi.kat_id);
            ViewBag.pr_id = new SelectList(db.proizvodjacis, "id", "proizvodjac", proizvodi.pr_id);
            return View(proizvodi);
        }

        // POST: Proizvodi/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,naziv,kat_id,dob_id,pr_id,cena")] proizvodi proizvodi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(proizvodi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dob_id = new SelectList(db.dobavljacis, "id", "dobavljac", proizvodi.dob_id);
            ViewBag.kat_id = new SelectList(db.kategorijes, "id", "kategorija", proizvodi.kat_id);
            ViewBag.pr_id = new SelectList(db.proizvodjacis, "id", "proizvodjac", proizvodi.pr_id);
            return View(proizvodi);
        }

        // GET: Proizvodi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            proizvodi proizvodi = db.proizvodis.Find(id);
            if (proizvodi == null)
            {
                return HttpNotFound();
            }
            return View(proizvodi);
        }

        // POST: Proizvodi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            proizvodi proizvodi = db.proizvodis.Find(id);
            db.proizvodis.Remove(proizvodi);
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

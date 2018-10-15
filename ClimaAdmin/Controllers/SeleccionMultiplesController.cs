using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClimaAdmin.Models;

namespace ClimaAdmin.Controllers
{
    public class SeleccionMultiplesController : Controller
    {
        private ClimaEntities db = new ClimaEntities();

        // GET: SeleccionMultiples
        public ActionResult Index()
        {
            var seleccionMultiples = db.SeleccionMultiples.Include(s => s.Dimensiones);
            return View(seleccionMultiples.ToList());
        }

        // GET: SeleccionMultiples/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeleccionMultiples seleccionMultiples = db.SeleccionMultiples.Find(id);
            if (seleccionMultiples == null)
            {
                return HttpNotFound();
            }
            return View(seleccionMultiples);
        }

        // GET: SeleccionMultiples/Create
        public ActionResult Create()
        {
            ViewBag.IdDimension = new SelectList(db.Dimensiones, "IdDimension", "Nombre");
            return View();
        }

        // POST: SeleccionMultiples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSeleccionMultiple,Enunciado,IdDimension")] SeleccionMultiples seleccionMultiples)
        {
            if (ModelState.IsValid)
            {
                db.SeleccionMultiples.Add(seleccionMultiples);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDimension = new SelectList(db.Dimensiones, "IdDimension", "Nombre", seleccionMultiples.IdDimension);
            return View(seleccionMultiples);
        }

        // GET: SeleccionMultiples/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeleccionMultiples seleccionMultiples = db.SeleccionMultiples.Find(id);
            if (seleccionMultiples == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDimension = new SelectList(db.Dimensiones, "IdDimension", "Nombre", seleccionMultiples.IdDimension);
            return View(seleccionMultiples);
        }

        // POST: SeleccionMultiples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSeleccionMultiple,Enunciado,IdDimension")] SeleccionMultiples seleccionMultiples)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seleccionMultiples).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDimension = new SelectList(db.Dimensiones, "IdDimension", "Nombre", seleccionMultiples.IdDimension);
            return View(seleccionMultiples);
        }

        // GET: SeleccionMultiples/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SeleccionMultiples seleccionMultiples = db.SeleccionMultiples.Find(id);
            if (seleccionMultiples == null)
            {
                return HttpNotFound();
            }
            return View(seleccionMultiples);
        }

        // POST: SeleccionMultiples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SeleccionMultiples seleccionMultiples = db.SeleccionMultiples.Find(id);
            db.SeleccionMultiples.Remove(seleccionMultiples);
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

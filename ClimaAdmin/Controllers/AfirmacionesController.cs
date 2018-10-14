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
    public class AfirmacionesController : Controller
    {
        private ClimaEF db = new ClimaEF();

        // GET: Afirmaciones
        public ActionResult Index()
        {
            return View(db.Afirmaciones.ToList());
        }

        // GET: Afirmaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afirmaciones afirmaciones = db.Afirmaciones.Find(id);
            if (afirmaciones == null)
            {
                return HttpNotFound();
            }
            return View(afirmaciones);
        }

        // GET: Afirmaciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Afirmaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAfirmacion,Enunciado")] Afirmaciones afirmaciones)
        {
            if (ModelState.IsValid)
            {
                db.Afirmaciones.Add(afirmaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(afirmaciones);
        }

        // GET: Afirmaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afirmaciones afirmaciones = db.Afirmaciones.Find(id);
            if (afirmaciones == null)
            {
                return HttpNotFound();
            }
            return View(afirmaciones);
        }

        // POST: Afirmaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAfirmacion,Enunciado")] Afirmaciones afirmaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(afirmaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(afirmaciones);
        }

        // GET: Afirmaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afirmaciones afirmaciones = db.Afirmaciones.Find(id);
            if (afirmaciones == null)
            {
                return HttpNotFound();
            }
            return View(afirmaciones);
        }

        // POST: Afirmaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Afirmaciones afirmaciones = db.Afirmaciones.Find(id);
            db.Afirmaciones.Remove(afirmaciones);
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

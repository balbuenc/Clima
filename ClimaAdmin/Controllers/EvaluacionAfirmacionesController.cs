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
    public class EvaluacionAfirmacionesController : Controller
    {
        private ClimaEntities db = new ClimaEntities();

        // GET: EvaluacionAfirmaciones
        public ActionResult Index()
        {
            return View(db.EvaluacionAfirmaciones.ToList());
        }

        // GET: EvaluacionAfirmaciones/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvaluacionAfirmaciones evaluacionAfirmaciones = db.EvaluacionAfirmaciones.Find(id);
            if (evaluacionAfirmaciones == null)
            {
                return HttpNotFound();
            }
            return View(evaluacionAfirmaciones);
        }

        // GET: EvaluacionAfirmaciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EvaluacionAfirmaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Evaluacion,Descripcion")] EvaluacionAfirmaciones evaluacionAfirmaciones)
        {
            if (ModelState.IsValid)
            {
                db.EvaluacionAfirmaciones.Add(evaluacionAfirmaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(evaluacionAfirmaciones);
        }

        // GET: EvaluacionAfirmaciones/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvaluacionAfirmaciones evaluacionAfirmaciones = db.EvaluacionAfirmaciones.Find(id);
            if (evaluacionAfirmaciones == null)
            {
                return HttpNotFound();
            }
            return View(evaluacionAfirmaciones);
        }

        // POST: EvaluacionAfirmaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Evaluacion,Descripcion")] EvaluacionAfirmaciones evaluacionAfirmaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluacionAfirmaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evaluacionAfirmaciones);
        }

        // GET: EvaluacionAfirmaciones/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EvaluacionAfirmaciones evaluacionAfirmaciones = db.EvaluacionAfirmaciones.Find(id);
            if (evaluacionAfirmaciones == null)
            {
                return HttpNotFound();
            }
            return View(evaluacionAfirmaciones);
        }

        // POST: EvaluacionAfirmaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            EvaluacionAfirmaciones evaluacionAfirmaciones = db.EvaluacionAfirmaciones.Find(id);
            db.EvaluacionAfirmaciones.Remove(evaluacionAfirmaciones);
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

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
    public class EncuestaPreguntasController : Controller
    {
        private ClimaEF db = new ClimaEF();

        // GET: EncuestaPreguntas
        public ActionResult Index()
        {
            var encuestaPreguntas = db.EncuestaPreguntas.Include(e => e.Afirmaciones).Include(e => e.Dimensiones).Include(e => e.Encuestas).Include(e => e.TipoPreguntas);
            return View(encuestaPreguntas.ToList());
        }

        // GET: EncuestaPreguntas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EncuestaPreguntas encuestaPreguntas = db.EncuestaPreguntas.Find(id);
            if (encuestaPreguntas == null)
            {
                return HttpNotFound();
            }
            return View(encuestaPreguntas);
        }

        // GET: EncuestaPreguntas/Create
        public ActionResult Create()
        {
            ViewBag.IdAfirmacion = new SelectList(db.Afirmaciones, "IdAfirmacion", "Enunciado");
            ViewBag.IdDimension = new SelectList(db.Dimensiones, "IdDimension", "Nombre");
            ViewBag.IdEncuesta = new SelectList(db.Encuestas, "IdEncuesta", "Nombre");
            ViewBag.IdTipoPregunta = new SelectList(db.TipoPreguntas, "IdTipoPregunta", "Tipo");
            return View();
        }

        // POST: EncuestaPreguntas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEncuesta,IdAfirmacion,IdDimension,IdTipoPregunta")] EncuestaPreguntas encuestaPreguntas)
        {
            if (ModelState.IsValid)
            {
                db.EncuestaPreguntas.Add(encuestaPreguntas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAfirmacion = new SelectList(db.Afirmaciones, "IdAfirmacion", "Enunciado", encuestaPreguntas.IdAfirmacion);
            ViewBag.IdDimension = new SelectList(db.Dimensiones, "IdDimension", "Nombre", encuestaPreguntas.IdDimension);
            ViewBag.IdEncuesta = new SelectList(db.Encuestas, "IdEncuesta", "Nombre", encuestaPreguntas.IdEncuesta);
            ViewBag.IdTipoPregunta = new SelectList(db.TipoPreguntas, "IdTipoPregunta", "Tipo", encuestaPreguntas.IdTipoPregunta);
            return View(encuestaPreguntas);
        }

        // GET: EncuestaPreguntas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EncuestaPreguntas encuestaPreguntas = db.EncuestaPreguntas.Find(id);
            if (encuestaPreguntas == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAfirmacion = new SelectList(db.Afirmaciones, "IdAfirmacion", "Enunciado", encuestaPreguntas.IdAfirmacion);
            ViewBag.IdDimension = new SelectList(db.Dimensiones, "IdDimension", "Nombre", encuestaPreguntas.IdDimension);
            ViewBag.IdEncuesta = new SelectList(db.Encuestas, "IdEncuesta", "Nombre", encuestaPreguntas.IdEncuesta);
            ViewBag.IdTipoPregunta = new SelectList(db.TipoPreguntas, "IdTipoPregunta", "Tipo", encuestaPreguntas.IdTipoPregunta);
            return View(encuestaPreguntas);
        }

        // POST: EncuestaPreguntas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEncuesta,IdAfirmacion,IdDimension,IdTipoPregunta")] EncuestaPreguntas encuestaPreguntas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(encuestaPreguntas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAfirmacion = new SelectList(db.Afirmaciones, "IdAfirmacion", "Enunciado", encuestaPreguntas.IdAfirmacion);
            ViewBag.IdDimension = new SelectList(db.Dimensiones, "IdDimension", "Nombre", encuestaPreguntas.IdDimension);
            ViewBag.IdEncuesta = new SelectList(db.Encuestas, "IdEncuesta", "Nombre", encuestaPreguntas.IdEncuesta);
            ViewBag.IdTipoPregunta = new SelectList(db.TipoPreguntas, "IdTipoPregunta", "Tipo", encuestaPreguntas.IdTipoPregunta);
            return View(encuestaPreguntas);
        }

        // GET: EncuestaPreguntas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EncuestaPreguntas encuestaPreguntas = db.EncuestaPreguntas.Find(id);
            if (encuestaPreguntas == null)
            {
                return HttpNotFound();
            }
            return View(encuestaPreguntas);
        }

        // POST: EncuestaPreguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EncuestaPreguntas encuestaPreguntas = db.EncuestaPreguntas.Find(id);
            db.EncuestaPreguntas.Remove(encuestaPreguntas);
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

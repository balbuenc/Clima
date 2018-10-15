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
        private ClimaEntities db = new ClimaEntities();

        // GET: EncuestaPreguntas
        public ActionResult Index()
        {
            var encuestaPreguntas = db.EncuestaPreguntas.Include(e => e.Afirmaciones).Include(e => e.Encuestas).Include(e => e.Preguntas).Include(e => e.SeleccionMultiples).Include(e => e.TipoPreguntas);
            return View(encuestaPreguntas.ToList());
        }

        // GET: EncuestaPreguntas/Details/5
        public ActionResult Details(long? id)
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
            ViewBag.IdEncuesta = new SelectList(db.Encuestas, "IdEncuesta", "Nombre");
            ViewBag.IdPregunta = new SelectList(db.Preguntas, "IdPregunta", "Enunciado");
            ViewBag.IdSeleccionMultiple = new SelectList(db.SeleccionMultiples, "IdSeleccionMultiple", "Enunciado");
            ViewBag.IdTipoPregunta = new SelectList(db.TipoPreguntas, "IdTipoPregunta", "Tipo");
            return View();
        }

        // POST: EncuestaPreguntas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEncuesta,IdTipoPregunta,IdAfirmacion,IdPregunta,Id,IdSeleccionMultiple")] EncuestaPreguntas encuestaPreguntas)
        {
            if (ModelState.IsValid)
            {
                db.EncuestaPreguntas.Add(encuestaPreguntas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAfirmacion = new SelectList(db.Afirmaciones, "IdAfirmacion", "Enunciado", encuestaPreguntas.IdAfirmacion);
            ViewBag.IdEncuesta = new SelectList(db.Encuestas, "IdEncuesta", "Nombre", encuestaPreguntas.IdEncuesta);
            ViewBag.IdPregunta = new SelectList(db.Preguntas, "IdPregunta", "Enunciado", encuestaPreguntas.IdPregunta);
            ViewBag.IdSeleccionMultiple = new SelectList(db.SeleccionMultiples, "IdSeleccionMultiple", "Enunciado", encuestaPreguntas.IdSeleccionMultiple);
            ViewBag.IdTipoPregunta = new SelectList(db.TipoPreguntas, "IdTipoPregunta", "Tipo", encuestaPreguntas.IdTipoPregunta);
            return View(encuestaPreguntas);
        }

        // GET: EncuestaPreguntas/Edit/5
        public ActionResult Edit(long? id)
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
            ViewBag.IdEncuesta = new SelectList(db.Encuestas, "IdEncuesta", "Nombre", encuestaPreguntas.IdEncuesta);
            ViewBag.IdPregunta = new SelectList(db.Preguntas, "IdPregunta", "Enunciado", encuestaPreguntas.IdPregunta);
            ViewBag.IdSeleccionMultiple = new SelectList(db.SeleccionMultiples, "IdSeleccionMultiple", "Enunciado", encuestaPreguntas.IdSeleccionMultiple);
            ViewBag.IdTipoPregunta = new SelectList(db.TipoPreguntas, "IdTipoPregunta", "Tipo", encuestaPreguntas.IdTipoPregunta);
            return View(encuestaPreguntas);
        }

        // POST: EncuestaPreguntas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEncuesta,IdTipoPregunta,IdAfirmacion,IdPregunta,Id,IdSeleccionMultiple")] EncuestaPreguntas encuestaPreguntas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(encuestaPreguntas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAfirmacion = new SelectList(db.Afirmaciones, "IdAfirmacion", "Enunciado", encuestaPreguntas.IdAfirmacion);
            ViewBag.IdEncuesta = new SelectList(db.Encuestas, "IdEncuesta", "Nombre", encuestaPreguntas.IdEncuesta);
            ViewBag.IdPregunta = new SelectList(db.Preguntas, "IdPregunta", "Enunciado", encuestaPreguntas.IdPregunta);
            ViewBag.IdSeleccionMultiple = new SelectList(db.SeleccionMultiples, "IdSeleccionMultiple", "Enunciado", encuestaPreguntas.IdSeleccionMultiple);
            ViewBag.IdTipoPregunta = new SelectList(db.TipoPreguntas, "IdTipoPregunta", "Tipo", encuestaPreguntas.IdTipoPregunta);
            return View(encuestaPreguntas);
        }

        // GET: EncuestaPreguntas/Delete/5
        public ActionResult Delete(long? id)
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
        public ActionResult DeleteConfirmed(long id)
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

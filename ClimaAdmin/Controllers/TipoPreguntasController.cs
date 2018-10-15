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
    public class TipoPreguntasController : Controller
    {
        private ClimaEntities db = new ClimaEntities();

        // GET: TipoPreguntas
        public ActionResult Index()
        {
            return View(db.TipoPreguntas.ToList());
        }

        // GET: TipoPreguntas/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPreguntas tipoPreguntas = db.TipoPreguntas.Find(id);
            if (tipoPreguntas == null)
            {
                return HttpNotFound();
            }
            return View(tipoPreguntas);
        }

        // GET: TipoPreguntas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPreguntas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTipoPregunta,Tipo")] TipoPreguntas tipoPreguntas)
        {
            if (ModelState.IsValid)
            {
                db.TipoPreguntas.Add(tipoPreguntas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoPreguntas);
        }

        // GET: TipoPreguntas/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPreguntas tipoPreguntas = db.TipoPreguntas.Find(id);
            if (tipoPreguntas == null)
            {
                return HttpNotFound();
            }
            return View(tipoPreguntas);
        }

        // POST: TipoPreguntas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTipoPregunta,Tipo")] TipoPreguntas tipoPreguntas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoPreguntas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoPreguntas);
        }

        // GET: TipoPreguntas/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPreguntas tipoPreguntas = db.TipoPreguntas.Find(id);
            if (tipoPreguntas == null)
            {
                return HttpNotFound();
            }
            return View(tipoPreguntas);
        }

        // POST: TipoPreguntas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            TipoPreguntas tipoPreguntas = db.TipoPreguntas.Find(id);
            db.TipoPreguntas.Remove(tipoPreguntas);
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

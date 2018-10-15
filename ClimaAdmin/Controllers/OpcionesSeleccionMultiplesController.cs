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
    public class OpcionesSeleccionMultiplesController : Controller
    {
        private ClimaEntities db = new ClimaEntities();

        // GET: OpcionesSeleccionMultiples
        public ActionResult Index()
        {
            var opcionesSeleccionMultiple = db.OpcionesSeleccionMultiple.Include(o => o.SeleccionMultiples);
            return View(opcionesSeleccionMultiple.ToList());
        }

        // GET: OpcionesSeleccionMultiples/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpcionesSeleccionMultiple opcionesSeleccionMultiple = db.OpcionesSeleccionMultiple.Find(id);
            if (opcionesSeleccionMultiple == null)
            {
                return HttpNotFound();
            }
            return View(opcionesSeleccionMultiple);
        }

        // GET: OpcionesSeleccionMultiples/Create
        public ActionResult Create()
        {
            ViewBag.IdSeleccionMultiple = new SelectList(db.SeleccionMultiples, "IdSeleccionMultiple", "Enunciado");
            return View();
        }

        // POST: OpcionesSeleccionMultiples/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdSeleccionMultiple,Valor,Id")] OpcionesSeleccionMultiple opcionesSeleccionMultiple)
        {
            if (ModelState.IsValid)
            {
                db.OpcionesSeleccionMultiple.Add(opcionesSeleccionMultiple);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdSeleccionMultiple = new SelectList(db.SeleccionMultiples, "IdSeleccionMultiple", "Enunciado", opcionesSeleccionMultiple.IdSeleccionMultiple);
            return View(opcionesSeleccionMultiple);
        }

        // GET: OpcionesSeleccionMultiples/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpcionesSeleccionMultiple opcionesSeleccionMultiple = db.OpcionesSeleccionMultiple.Find(id);
            if (opcionesSeleccionMultiple == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdSeleccionMultiple = new SelectList(db.SeleccionMultiples, "IdSeleccionMultiple", "Enunciado", opcionesSeleccionMultiple.IdSeleccionMultiple);
            return View(opcionesSeleccionMultiple);
        }

        // POST: OpcionesSeleccionMultiples/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSeleccionMultiple,Valor,Id")] OpcionesSeleccionMultiple opcionesSeleccionMultiple)
        {
            if (ModelState.IsValid)
            {
                db.Entry(opcionesSeleccionMultiple).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdSeleccionMultiple = new SelectList(db.SeleccionMultiples, "IdSeleccionMultiple", "Enunciado", opcionesSeleccionMultiple.IdSeleccionMultiple);
            return View(opcionesSeleccionMultiple);
        }

        // GET: OpcionesSeleccionMultiples/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpcionesSeleccionMultiple opcionesSeleccionMultiple = db.OpcionesSeleccionMultiple.Find(id);
            if (opcionesSeleccionMultiple == null)
            {
                return HttpNotFound();
            }
            return View(opcionesSeleccionMultiple);
        }

        // POST: OpcionesSeleccionMultiples/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            OpcionesSeleccionMultiple opcionesSeleccionMultiple = db.OpcionesSeleccionMultiple.Find(id);
            db.OpcionesSeleccionMultiple.Remove(opcionesSeleccionMultiple);
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

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
    public class DimensionesController : Controller
    {
        private ClimaEntities db = new ClimaEntities();

        // GET: Dimensiones
        public ActionResult Index()
        {
            return View(db.Dimensiones.ToList());
        }

        // GET: Dimensiones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dimensiones dimensiones = db.Dimensiones.Find(id);
            if (dimensiones == null)
            {
                return HttpNotFound();
            }
            return View(dimensiones);
        }

        // GET: Dimensiones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dimensiones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDimension,Nombre,Descripcion")] Dimensiones dimensiones)
        {
            if (ModelState.IsValid)
            {
                db.Dimensiones.Add(dimensiones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dimensiones);
        }

        // GET: Dimensiones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dimensiones dimensiones = db.Dimensiones.Find(id);
            if (dimensiones == null)
            {
                return HttpNotFound();
            }
            return View(dimensiones);
        }

        // POST: Dimensiones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDimension,Nombre,Descripcion")] Dimensiones dimensiones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dimensiones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dimensiones);
        }

        // GET: Dimensiones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dimensiones dimensiones = db.Dimensiones.Find(id);
            if (dimensiones == null)
            {
                return HttpNotFound();
            }
            return View(dimensiones);
        }

        // POST: Dimensiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dimensiones dimensiones = db.Dimensiones.Find(id);
            db.Dimensiones.Remove(dimensiones);
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

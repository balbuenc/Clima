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
    public class AsignacionesEmpresasController : Controller
    {
        private ClimaEntities db = new ClimaEntities();

        // GET: AsignacionesEmpresas
        public ActionResult Index()
        {
            var asignacionesEmpresas = db.AsignacionesEmpresas.Include(a => a.Empresas).Include(a => a.Encuestas);
            return View(asignacionesEmpresas.ToList());
        }

        // GET: AsignacionesEmpresas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionesEmpresas asignacionesEmpresas = db.AsignacionesEmpresas.Find(id);
            if (asignacionesEmpresas == null)
            {
                return HttpNotFound();
            }
            return View(asignacionesEmpresas);
        }

        // GET: AsignacionesEmpresas/Create
        public ActionResult Create()
        {
            ViewBag.cod_empresa = new SelectList(db.Empresas, "cod_empresa", "Empresa");
            ViewBag.IdEncuesta = new SelectList(db.Encuestas, "IdEncuesta", "Nombre");
            return View();
        }

        // POST: AsignacionesEmpresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEncuesta,cod_empresa,Observaciones")] AsignacionesEmpresas asignacionesEmpresas)
        {
            if (ModelState.IsValid)
            {
                db.AsignacionesEmpresas.Add(asignacionesEmpresas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_empresa = new SelectList(db.Empresas, "cod_empresa", "Empresa", asignacionesEmpresas.cod_empresa);
            ViewBag.IdEncuesta = new SelectList(db.Encuestas, "IdEncuesta", "Nombre", asignacionesEmpresas.IdEncuesta);
            return View(asignacionesEmpresas);
        }

        // GET: AsignacionesEmpresas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionesEmpresas asignacionesEmpresas = db.AsignacionesEmpresas.Find(id);
            if (asignacionesEmpresas == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_empresa = new SelectList(db.Empresas, "cod_empresa", "Empresa", asignacionesEmpresas.cod_empresa);
            ViewBag.IdEncuesta = new SelectList(db.Encuestas, "IdEncuesta", "Nombre", asignacionesEmpresas.IdEncuesta);
            return View(asignacionesEmpresas);
        }

        // POST: AsignacionesEmpresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEncuesta,cod_empresa,Observaciones")] AsignacionesEmpresas asignacionesEmpresas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asignacionesEmpresas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_empresa = new SelectList(db.Empresas, "cod_empresa", "Empresa", asignacionesEmpresas.cod_empresa);
            ViewBag.IdEncuesta = new SelectList(db.Encuestas, "IdEncuesta", "Nombre", asignacionesEmpresas.IdEncuesta);
            return View(asignacionesEmpresas);
        }

        // GET: AsignacionesEmpresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsignacionesEmpresas asignacionesEmpresas = db.AsignacionesEmpresas.Find(id);
            if (asignacionesEmpresas == null)
            {
                return HttpNotFound();
            }
            return View(asignacionesEmpresas);
        }

        // POST: AsignacionesEmpresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsignacionesEmpresas asignacionesEmpresas = db.AsignacionesEmpresas.Find(id);
            db.AsignacionesEmpresas.Remove(asignacionesEmpresas);
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

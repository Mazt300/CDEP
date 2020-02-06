using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ControlDeEpidemias.Models;

namespace ControlDeEpidemias.Controllers
{
    public class LaboratorioController : Controller
    {
        private ControlDeEpidemiasEntities db = new ControlDeEpidemiasEntities();

        // GET: Laboratorio
        public ActionResult Index()
        {
            var laboratorio = db.Laboratorio.Include(l => l.enfermero);
            return View(laboratorio.ToList());
        }

        // GET: Laboratorio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laboratorio laboratorio = db.Laboratorio.Find(id);
            if (laboratorio == null)
            {
                return HttpNotFound();
            }
            return View(laboratorio);
        }

        // GET: Laboratorio/Create
        public ActionResult Create()
        {
            ViewBag.idenfermero = new SelectList(db.enfermero, "idenfermero", "idenfermero");
            ViewBag.Nombre_enfermero = new SelectList(db.enfermero.Where(c => c.idempleado == c.Empleado.idempleado).Select(c => new { idempleado = c.idempleado, Nombre = c.Empleado.Nombre }),"idempleado","Nombre");
            ViewBag.Apellido_enfermero = new SelectList(db.enfermero.Where(c => c.idempleado == c.Empleado.idempleado).Select(c => new { idempleado = c.idempleado, Apellido = c.Empleado.Apellido }), "idempleado", "Apellido");
            return View();
        }

        // POST: Laboratorio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idlaboratorio,Nombre,idenfermero,estado")] Laboratorio laboratorio)
        {
            if (ModelState.IsValid)
            {
                db.Laboratorio.Add(laboratorio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idenfermero = new SelectList(db.enfermero, "idenfermero", "idenfermero", laboratorio.idenfermero);
            return View(laboratorio);
        }

        // GET: Laboratorio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laboratorio laboratorio = db.Laboratorio.Find(id);
            if (laboratorio == null)
            {
                return HttpNotFound();
            }
            ViewBag.idenfermero = new SelectList(db.enfermero, "idenfermero", "idenfermero", laboratorio.idenfermero);
            return View(laboratorio);
        }

        // POST: Laboratorio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idlaboratorio,Nombre,idenfermero,estado")] Laboratorio laboratorio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(laboratorio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idenfermero = new SelectList(db.enfermero, "idenfermero", "idenfermero", laboratorio.idenfermero);
            return View(laboratorio);
        }

        // GET: Laboratorio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Laboratorio laboratorio = db.Laboratorio.Find(id);
            if (laboratorio == null)
            {
                return HttpNotFound();
            }
            return View(laboratorio);
        }

        // POST: Laboratorio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Laboratorio laboratorio = db.Laboratorio.Find(id);
            db.Laboratorio.Remove(laboratorio);
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

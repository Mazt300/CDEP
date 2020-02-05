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
    public class ExamenController : Controller
    {
        private ControlDeEpidemiasEntities db = new ControlDeEpidemiasEntities();

        // GET: Examen
        public ActionResult Index()
        {
            var examen = db.Examen.Include(e => e.Laboratorio).Include(e => e.Medico).Include(e => e.OrdenDeExamen);
            return View(examen.ToList());
        }

        // GET: Examen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examen examen = db.Examen.Find(id);
            if (examen == null)
            {
                return HttpNotFound();
            }
            return View(examen);
        }

        // GET: Examen/Create
        public ActionResult Create()
        {
            ViewBag.idLaboratorio = new SelectList(db.Laboratorio, "idlaboratorio", "Nombre");
            ViewBag.idmedico = new SelectList(db.Medico, "idmedico", "idmedico");
            ViewBag.idordenexamen = new SelectList(db.OrdenDeExamen, "idOrdenDeExamen", "estado");
            return View();
        }

        // POST: Examen/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idexamen,Nombre,idordenexamen,idLaboratorio,idmedico,FechaRealizacion,estado")] Examen examen)
        {
            if (ModelState.IsValid)
            {
                db.Examen.Add(examen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idLaboratorio = new SelectList(db.Laboratorio, "idlaboratorio", "Nombre", examen.idLaboratorio);
            ViewBag.idmedico = new SelectList(db.Medico, "idmedico", "idmedico", examen.idmedico);
            ViewBag.idordenexamen = new SelectList(db.OrdenDeExamen, "idOrdenDeExamen", "estado", examen.idordenexamen);
            return View(examen);
        }

        // GET: Examen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examen examen = db.Examen.Find(id);
            if (examen == null)
            {
                return HttpNotFound();
            }
            ViewBag.idLaboratorio = new SelectList(db.Laboratorio, "idlaboratorio", "Nombre", examen.idLaboratorio);
            ViewBag.idmedico = new SelectList(db.Medico, "idmedico", "idmedico", examen.idmedico);
            ViewBag.idordenexamen = new SelectList(db.OrdenDeExamen, "idOrdenDeExamen", "estado", examen.idordenexamen);
            return View(examen);
        }

        // POST: Examen/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idexamen,Nombre,idordenexamen,idLaboratorio,idmedico,FechaRealizacion,estado")] Examen examen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(examen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idLaboratorio = new SelectList(db.Laboratorio, "idlaboratorio", "Nombre", examen.idLaboratorio);
            ViewBag.idmedico = new SelectList(db.Medico, "idmedico", "idmedico", examen.idmedico);
            ViewBag.idordenexamen = new SelectList(db.OrdenDeExamen, "idOrdenDeExamen", "estado", examen.idordenexamen);
            return View(examen);
        }

        // GET: Examen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Examen examen = db.Examen.Find(id);
            if (examen == null)
            {
                return HttpNotFound();
            }
            return View(examen);
        }

        // POST: Examen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Examen examen = db.Examen.Find(id);
            db.Examen.Remove(examen);
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

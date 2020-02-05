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
    public class OrdenDeExamenController : Controller
    {
        private ControlDeEpidemiasEntities db = new ControlDeEpidemiasEntities();

        // GET: OrdenDeExamen
        public ActionResult Index()
        {
            var ordenDeExamen = db.OrdenDeExamen.Include(o => o.Medico).Include(o => o.paciente);
            return View(ordenDeExamen.ToList());
        }

        // GET: OrdenDeExamen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenDeExamen ordenDeExamen = db.OrdenDeExamen.Find(id);
            if (ordenDeExamen == null)
            {
                return HttpNotFound();
            }
            return View(ordenDeExamen);
        }

        // GET: OrdenDeExamen/Create
        public ActionResult Create()
        {
            ViewBag.idmedico = new SelectList(db.Medico, "idmedico", "idmedico");
            ViewBag.idpaciente = new SelectList(db.paciente, "idpaciente", "nombre");
            return View();
        }

        // POST: OrdenDeExamen/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idOrdenDeExamen,idpaciente,fechaorden,idmedico,estado")] OrdenDeExamen ordenDeExamen)
        {
            if (ModelState.IsValid)
            {
                db.OrdenDeExamen.Add(ordenDeExamen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idmedico = new SelectList(db.Medico, "idmedico", "idmedico", ordenDeExamen.idmedico);
            ViewBag.idpaciente = new SelectList(db.paciente, "idpaciente", "nombre", ordenDeExamen.idpaciente);
            return View(ordenDeExamen);
        }

        // GET: OrdenDeExamen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenDeExamen ordenDeExamen = db.OrdenDeExamen.Find(id);
            if (ordenDeExamen == null)
            {
                return HttpNotFound();
            }
            ViewBag.idmedico = new SelectList(db.Medico, "idmedico", "idmedico", ordenDeExamen.idmedico);
            ViewBag.idpaciente = new SelectList(db.paciente, "idpaciente", "nombre", ordenDeExamen.idpaciente);
            return View(ordenDeExamen);
        }

        // POST: OrdenDeExamen/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idOrdenDeExamen,idpaciente,fechaorden,idmedico,estado")] OrdenDeExamen ordenDeExamen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordenDeExamen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idmedico = new SelectList(db.Medico, "idmedico", "idmedico", ordenDeExamen.idmedico);
            ViewBag.idpaciente = new SelectList(db.paciente, "idpaciente", "nombre", ordenDeExamen.idpaciente);
            return View(ordenDeExamen);
        }

        // GET: OrdenDeExamen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdenDeExamen ordenDeExamen = db.OrdenDeExamen.Find(id);
            if (ordenDeExamen == null)
            {
                return HttpNotFound();
            }
            return View(ordenDeExamen);
        }

        // POST: OrdenDeExamen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenDeExamen ordenDeExamen = db.OrdenDeExamen.Find(id);
            db.OrdenDeExamen.Remove(ordenDeExamen);
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

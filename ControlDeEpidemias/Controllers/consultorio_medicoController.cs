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
    public class consultorio_medicoController : Controller
    {
        private ControlDeEpidemiasEntities db = new ControlDeEpidemiasEntities();

        // GET: consultorio_medico
        public ActionResult Index()
        {
            var consultorio_medico = db.consultorio_medico.Include(c => c.Consultorio).Include(c => c.Medico);
            return View(consultorio_medico.ToList());
        }

        // GET: consultorio_medico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consultorio_medico consultorio_medico = db.consultorio_medico.Find(id);
            if (consultorio_medico == null)
            {
                return HttpNotFound();
            }
            return View(consultorio_medico);
        }

        // GET: consultorio_medico/Create
        public ActionResult Create()
        {
            ViewBag.idconsultorio = new SelectList(db.Consultorio, "idconsultorio", "nombreconsultorio");
            ViewBag.idmedico = new SelectList(db.Medico.Where(c => c.idempleado == c.Empleado.idempleado), "idempleado", "Nombre");
            return View();
        }

        // POST: consultorio_medico/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idconsultorio_medico,idconsultorio,idmedico,estado")] consultorio_medico consultorio_medico)
        {
            if (ModelState.IsValid)
            {
                db.consultorio_medico.Add(consultorio_medico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idconsultorio = new SelectList(db.Consultorio, "idconsultorio", "nombreconsultorio", consultorio_medico.idconsultorio);
            ViewBag.idmedico = new SelectList(db.Medico, "idmedico", "idmedico", consultorio_medico.idmedico);
            return View(consultorio_medico);
        }

        // GET: consultorio_medico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consultorio_medico consultorio_medico = db.consultorio_medico.Find(id);
            if (consultorio_medico == null)
            {
                return HttpNotFound();
            }
            ViewBag.idconsultorio = new SelectList(db.Consultorio, "idconsultorio", "nombreconsultorio", consultorio_medico.idconsultorio);
            ViewBag.idmedico = new SelectList(db.Medico, "idmedico", "idmedico", consultorio_medico.idmedico);
            return View(consultorio_medico);
        }

        // POST: consultorio_medico/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idconsultorio_medico,idconsultorio,idmedico,estado")] consultorio_medico consultorio_medico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consultorio_medico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idconsultorio = new SelectList(db.Consultorio, "idconsultorio", "nombreconsultorio", consultorio_medico.idconsultorio);
            ViewBag.idmedico = new SelectList(db.Medico, "idmedico", "idmedico", consultorio_medico.idmedico);
            return View(consultorio_medico);
        }

        // GET: consultorio_medico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            consultorio_medico consultorio_medico = db.consultorio_medico.Find(id);
            if (consultorio_medico == null)
            {
                return HttpNotFound();
            }
            return View(consultorio_medico);
        }

        // POST: consultorio_medico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            consultorio_medico consultorio_medico = db.consultorio_medico.Find(id);
            db.consultorio_medico.Remove(consultorio_medico);
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

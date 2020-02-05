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
    public class ConsultorioController : Controller
    {
        private ControlDeEpidemiasEntities db = new ControlDeEpidemiasEntities();

        // GET: Consultorio
        public ActionResult Index()
        {
            var consultorio = db.Consultorio.Include(c => c.consultorio_medico);
            return View(consultorio.ToList());
        }

        // GET: Consultorio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultorio consultorio = db.Consultorio.Find(id);
            if (consultorio == null)
            {
                return HttpNotFound();
            }
            return View(consultorio);
        }

        // GET: Consultorio/Create
        public ActionResult Create()
        {
            ViewBag.idconsultorio = new SelectList(db.consultorio_medico, "idconsultorio_medico", "idconsultorio_medico");
            return View();
        }

        // POST: Consultorio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idconsultorio,nombreconsultorio,estado")] Consultorio consultorio)
        {
            if (ModelState.IsValid)
            {
                db.Consultorio.Add(consultorio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idconsultorio = new SelectList(db.consultorio_medico, "idconsultorio_medico", "idconsultorio_medico", consultorio.idconsultorio);
            return View(consultorio);
        }

        // GET: Consultorio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultorio consultorio = db.Consultorio.Find(id);
            if (consultorio == null)
            {
                return HttpNotFound();
            }
            ViewBag.idconsultorio = new SelectList(db.consultorio_medico, "idconsultorio_medico", "idconsultorio_medico", consultorio.idconsultorio);
            return View(consultorio);
        }

        // POST: Consultorio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idconsultorio,nombreconsultorio,estado")] Consultorio consultorio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consultorio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idconsultorio = new SelectList(db.consultorio_medico, "idconsultorio_medico", "idconsultorio_medico", consultorio.idconsultorio);
            return View(consultorio);
        }

        // GET: Consultorio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consultorio consultorio = db.Consultorio.Find(id);
            if (consultorio == null)
            {
                return HttpNotFound();
            }
            return View(consultorio);
        }

        // POST: Consultorio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consultorio consultorio = db.Consultorio.Find(id);
            db.Consultorio.Remove(consultorio);
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

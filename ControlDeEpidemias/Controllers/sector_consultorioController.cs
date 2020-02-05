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
    public class sector_consultorioController : Controller
    {
        private ControlDeEpidemiasEntities db = new ControlDeEpidemiasEntities();

        // GET: sector_consultorio
        public ActionResult Index()
        {
            var sector_consultorio = db.sector_consultorio.Include(s => s.Consultorio).Include(s => s.sector);
            return View(sector_consultorio.ToList());
        }

        // GET: sector_consultorio/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sector_consultorio sector_consultorio = db.sector_consultorio.Find(id);
            if (sector_consultorio == null)
            {
                return HttpNotFound();
            }
            return View(sector_consultorio);
        }

        // GET: sector_consultorio/Create
        public ActionResult Create()
        {
            ViewBag.idconsultorio = new SelectList(db.Consultorio, "idconsultorio", "nombreconsultorio");
            ViewBag.idsector = new SelectList(db.sector, "idsector", "Nombre");
            return View();
        }

        // POST: sector_consultorio/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idsector_consultorio,idsector,idconsultorio,estado")] sector_consultorio sector_consultorio)
        {
            if (ModelState.IsValid)
            {
                db.sector_consultorio.Add(sector_consultorio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idconsultorio = new SelectList(db.Consultorio, "idconsultorio", "nombreconsultorio", sector_consultorio.idconsultorio);
            ViewBag.idsector = new SelectList(db.sector, "idsector", "Nombre", sector_consultorio.idsector);
            return View(sector_consultorio);
        }

        // GET: sector_consultorio/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sector_consultorio sector_consultorio = db.sector_consultorio.Find(id);
            if (sector_consultorio == null)
            {
                return HttpNotFound();
            }
            ViewBag.idconsultorio = new SelectList(db.Consultorio, "idconsultorio", "nombreconsultorio", sector_consultorio.idconsultorio);
            ViewBag.idsector = new SelectList(db.sector, "idsector", "Nombre", sector_consultorio.idsector);
            return View(sector_consultorio);
        }

        // POST: sector_consultorio/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idsector_consultorio,idsector,idconsultorio,estado")] sector_consultorio sector_consultorio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sector_consultorio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idconsultorio = new SelectList(db.Consultorio, "idconsultorio", "nombreconsultorio", sector_consultorio.idconsultorio);
            ViewBag.idsector = new SelectList(db.sector, "idsector", "Nombre", sector_consultorio.idsector);
            return View(sector_consultorio);
        }

        // GET: sector_consultorio/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sector_consultorio sector_consultorio = db.sector_consultorio.Find(id);
            if (sector_consultorio == null)
            {
                return HttpNotFound();
            }
            return View(sector_consultorio);
        }

        // POST: sector_consultorio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sector_consultorio sector_consultorio = db.sector_consultorio.Find(id);
            db.sector_consultorio.Remove(sector_consultorio);
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

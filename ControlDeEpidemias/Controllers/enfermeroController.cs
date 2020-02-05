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
    public class enfermeroController : Controller
    {
        private ControlDeEpidemiasEntities db = new ControlDeEpidemiasEntities();

        // GET: enfermero
        public ActionResult Index()
        {
            var enfermero = db.enfermero.Include(e => e.Empleado);
            return View(enfermero.ToList());
        }

        // GET: enfermero/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enfermero enfermero = db.enfermero.Find(id);
            if (enfermero == null)
            {
                return HttpNotFound();
            }
            return View(enfermero);
        }

        // GET: enfermero/Create
        public ActionResult Create()
        {
            ViewBag.idempleado = new SelectList(db.Empleado, "idempleado", "Nombre");
            return View();
        }

        // POST: enfermero/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idenfermero,idempleado,estado")] enfermero enfermero)
        {
            if (ModelState.IsValid)
            {
                db.enfermero.Add(enfermero);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idempleado = new SelectList(db.Empleado, "idempleado", "Nombre", enfermero.idempleado);
            return View(enfermero);
        }

        // GET: enfermero/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enfermero enfermero = db.enfermero.Find(id);
            if (enfermero == null)
            {
                return HttpNotFound();
            }
            ViewBag.idempleado = new SelectList(db.Empleado, "idempleado", "Nombre", enfermero.idempleado);
            return View(enfermero);
        }

        // POST: enfermero/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idenfermero,idempleado,estado")] enfermero enfermero)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enfermero).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idempleado = new SelectList(db.Empleado, "idempleado", "Nombre", enfermero.idempleado);
            return View(enfermero);
        }

        // GET: enfermero/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            enfermero enfermero = db.enfermero.Find(id);
            if (enfermero == null)
            {
                return HttpNotFound();
            }
            return View(enfermero);
        }

        // POST: enfermero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            enfermero enfermero = db.enfermero.Find(id);
            db.enfermero.Remove(enfermero);
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

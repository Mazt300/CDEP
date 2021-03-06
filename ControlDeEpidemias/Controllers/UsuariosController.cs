﻿using System;
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
    public class UsuariosController : Controller
    {
        private ControlDeEpidemiasEntities db = new ControlDeEpidemiasEntities();

        // GET: Usuarios
        public ActionResult Index()
        {
            var usuario = db.Usuario.Include(u => u.Empleado).Include(u => u.Permiso);
            return View(usuario.ToList());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        public ActionResult Login()
        {
            return View();
        }
        // GET: Usuarios/Create
        public ActionResult Create()
        {
            ViewBag.Empleado = new SelectList(db.Empleado.Select(c => new { idempleado = c.idempleado, Nombre = c.Nombre + " " + c.Apellido }), "idempleado", "Nombre");
            //ViewBag.Cedula = new SelectList(db.Empleado.Select(c => new { Cedula = c.Identificacion }), "idempleado", "Identificacion");
            ViewBag.idpermiso = new SelectList(db.Permiso, "idpermiso", "PermisoDe");
            return View();
        }

        // POST: Usuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idusuario,nombreusuario,contraseñausuario,idEmpleado,estado,idpermiso")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEmpleado = new SelectList(db.Empleado, "idempleado", "Nombre", usuario.idEmpleado);
            ViewBag.idpermiso = new SelectList(db.Permiso, "idpermiso", "idpermiso", usuario.idpermiso);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idempleado", "Nombre", usuario.idEmpleado);
            ViewBag.idEmpleado2 = new SelectList(db.Empleado, "idempleado", "Apellido", usuario.idEmpleado);
            ViewBag.idpermiso = new SelectList(db.Permiso, "idpermiso", "PermisoDe", usuario.idpermiso);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idusuario,nombreusuario,contraseñausuario,idEmpleado,estado,idpermiso")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEmpleado = new SelectList(db.Empleado, "idempleado", "Nombre",usuario.idEmpleado);
            ViewBag.idEmpleado2 = new SelectList(db.Empleado, "idempleado", "Apellido", usuario.idEmpleado);
            ViewBag.idpermiso = new SelectList(db.Permiso, "idpermiso", "PermisoDe", usuario.idpermiso);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
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

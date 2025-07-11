﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using pactica123.Models;

namespace pactica123.Controllers
{
    public class PersonasController : Controller
    {
        private InventarioEntities db = new InventarioEntities();

        // GET: Personas
        public ActionResult Index()
        {
            var personas = db.Personas.Include(p => p.Adscripcion).Include(p => p.Tabla_Tipos_Puesto);
            return View(personas.ToList());
        }

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personas personas = db.Personas.Find(id);
            if (personas == null)
            {
                return HttpNotFound();
            }
            return View(personas);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            ViewBag.id_adscripcion = new SelectList(db.Adscripcion, "id_adscripcion", "nombre_adscripcion");
            ViewBag.id_tipo_puesto = new SelectList(db.Tabla_Tipos_Puesto, "id_tipo_puesto", "descripcion_puesto");
            return View();
        }

        // POST: Personas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_persona,nombre,apellido,correo,telefono,id_tipo_puesto,id_adscripcion")] Personas personas)
        {
            if (ModelState.IsValid)
            {
                db.Personas.Add(personas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_adscripcion = new SelectList(db.Adscripcion, "id_adscripcion", "nombre_adscripcion", personas.id_adscripcion);
            ViewBag.id_tipo_puesto = new SelectList(db.Tabla_Tipos_Puesto, "id_tipo_puesto", "descripcion_puesto", personas.id_tipo_puesto);
            return View(personas);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personas personas = db.Personas.Find(id);
            if (personas == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_adscripcion = new SelectList(db.Adscripcion, "id_adscripcion", "nombre_adscripcion", personas.id_adscripcion);
            ViewBag.id_tipo_puesto = new SelectList(db.Tabla_Tipos_Puesto, "id_tipo_puesto", "descripcion_puesto", personas.id_tipo_puesto);
            return View(personas);
        }

        // POST: Personas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_persona,nombre,apellido,correo,telefono,id_tipo_puesto,id_adscripcion")] Personas personas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_adscripcion = new SelectList(db.Adscripcion, "id_adscripcion", "nombre_adscripcion", personas.id_adscripcion);
            ViewBag.id_tipo_puesto = new SelectList(db.Tabla_Tipos_Puesto, "id_tipo_puesto", "descripcion_puesto", personas.id_tipo_puesto);
            return View(personas);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personas personas = db.Personas.Find(id);
            if (personas == null)
            {
                return HttpNotFound();
            }
            return View(personas);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personas personas = db.Personas.Find(id);
            db.Personas.Remove(personas);
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

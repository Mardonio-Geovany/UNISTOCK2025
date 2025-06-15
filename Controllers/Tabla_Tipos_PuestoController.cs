using System;
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
    public class Tabla_Tipos_PuestoController : Controller
    {
        private InventarioEntities db = new InventarioEntities();

        // GET: Tabla_Tipos_Puesto
        public ActionResult Index()
        {
            return View(db.Tabla_Tipos_Puesto.ToList());
        }

        // GET: Tabla_Tipos_Puesto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabla_Tipos_Puesto tabla_Tipos_Puesto = db.Tabla_Tipos_Puesto.Find(id);
            if (tabla_Tipos_Puesto == null)
            {
                return HttpNotFound();
            }
            return View(tabla_Tipos_Puesto);
        }

        // GET: Tabla_Tipos_Puesto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tabla_Tipos_Puesto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_tipo_puesto,descripcion_puesto")] Tabla_Tipos_Puesto tabla_Tipos_Puesto)
        {
            if (ModelState.IsValid)
            {
                db.Tabla_Tipos_Puesto.Add(tabla_Tipos_Puesto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tabla_Tipos_Puesto);
        }

        // GET: Tabla_Tipos_Puesto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabla_Tipos_Puesto tabla_Tipos_Puesto = db.Tabla_Tipos_Puesto.Find(id);
            if (tabla_Tipos_Puesto == null)
            {
                return HttpNotFound();
            }
            return View(tabla_Tipos_Puesto);
        }

        // POST: Tabla_Tipos_Puesto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_tipo_puesto,descripcion_puesto")] Tabla_Tipos_Puesto tabla_Tipos_Puesto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabla_Tipos_Puesto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tabla_Tipos_Puesto);
        }

        // GET: Tabla_Tipos_Puesto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabla_Tipos_Puesto tabla_Tipos_Puesto = db.Tabla_Tipos_Puesto.Find(id);
            if (tabla_Tipos_Puesto == null)
            {
                return HttpNotFound();
            }
            return View(tabla_Tipos_Puesto);
        }

        // POST: Tabla_Tipos_Puesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tabla_Tipos_Puesto tabla_Tipos_Puesto = db.Tabla_Tipos_Puesto.Find(id);
            db.Tabla_Tipos_Puesto.Remove(tabla_Tipos_Puesto);
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

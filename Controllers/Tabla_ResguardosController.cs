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
    public class Tabla_ResguardosController : Controller
    {
        private InventarioEntities db = new InventarioEntities();

        // GET: Tabla_Resguardos
        public ActionResult Index()
        {
            var tabla_Resguardos = db.Tabla_Resguardos.Include(t => t.Personas);
            return View(tabla_Resguardos.ToList());
        }

        // GET: Tabla_Resguardos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabla_Resguardos tabla_Resguardos = db.Tabla_Resguardos.Find(id);
            if (tabla_Resguardos == null)
            {
                return HttpNotFound();
            }
            return View(tabla_Resguardos);
        }

        // GET: Tabla_Resguardos/Create
        public ActionResult Create()
        {
            ViewBag.id_persona = new SelectList(db.Personas, "id_persona", "nombre");
            return View();
        }

        // POST: Tabla_Resguardos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_resguardo,id_persona,fecha_entrega,id_Autoriza,id_Realiza")] Tabla_Resguardos tabla_Resguardos)
        {
            if (ModelState.IsValid)
            {
                db.Tabla_Resguardos.Add(tabla_Resguardos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_persona = new SelectList(db.Personas, "id_persona", "nombre", tabla_Resguardos.id_persona);
            return View(tabla_Resguardos);
        }

        // GET: Tabla_Resguardos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabla_Resguardos tabla_Resguardos = db.Tabla_Resguardos.Find(id);
            if (tabla_Resguardos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_persona = new SelectList(db.Personas, "id_persona", "nombre", tabla_Resguardos.id_persona);
            return View(tabla_Resguardos);
        }

        // POST: Tabla_Resguardos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_resguardo,id_persona,fecha_entrega,id_Autoriza,id_Realiza")] Tabla_Resguardos tabla_Resguardos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabla_Resguardos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_persona = new SelectList(db.Personas, "id_persona", "nombre", tabla_Resguardos.id_persona);
            return View(tabla_Resguardos);
        }

        // GET: Tabla_Resguardos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabla_Resguardos tabla_Resguardos = db.Tabla_Resguardos.Find(id);
            if (tabla_Resguardos == null)
            {
                return HttpNotFound();
            }
            return View(tabla_Resguardos);
        }

        // POST: Tabla_Resguardos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tabla_Resguardos tabla_Resguardos = db.Tabla_Resguardos.Find(id);
            db.Tabla_Resguardos.Remove(tabla_Resguardos);
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

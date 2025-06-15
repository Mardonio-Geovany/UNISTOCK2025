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
    public class AdscripcionsController : Controller
    {
        private InventarioEntities db = new InventarioEntities();

        // GET: Adscripcions
        public ActionResult Index()
        {
            return View(db.Adscripcion.ToList());
        }

        // GET: Adscripcions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adscripcion adscripcion = db.Adscripcion.Find(id);
            if (adscripcion == null)
            {
                return HttpNotFound();
            }
            return View(adscripcion);
        }

        // GET: Adscripcions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adscripcions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_adscripcion,nombre_adscripcion,ubicacion")] Adscripcion adscripcion)
        {
            if (ModelState.IsValid)
            {
                db.Adscripcion.Add(adscripcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adscripcion);
        }

        // GET: Adscripcions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adscripcion adscripcion = db.Adscripcion.Find(id);
            if (adscripcion == null)
            {
                return HttpNotFound();
            }
            return View(adscripcion);
        }

        // POST: Adscripcions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_adscripcion,nombre_adscripcion,ubicacion")] Adscripcion adscripcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adscripcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adscripcion);
        }

        // GET: Adscripcions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adscripcion adscripcion = db.Adscripcion.Find(id);
            if (adscripcion == null)
            {
                return HttpNotFound();
            }
            return View(adscripcion);
        }

        // POST: Adscripcions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adscripcion adscripcion = db.Adscripcion.Find(id);
            db.Adscripcion.Remove(adscripcion);
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

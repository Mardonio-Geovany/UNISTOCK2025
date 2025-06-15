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
    public class Detalle_Vale_PrestamoController : Controller
    {
        private InventarioEntities db = new InventarioEntities();

        // GET: Detalle_Vale_Prestamo
        public ActionResult Index()
        {
            var detalle_Vale_Prestamo = db.Detalle_Vale_Prestamo.Include(d => d.Vale_De_Prestamo);
            return View(detalle_Vale_Prestamo.ToList());
        }

        // GET: Detalle_Vale_Prestamo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Vale_Prestamo detalle_Vale_Prestamo = db.Detalle_Vale_Prestamo.Find(id);
            if (detalle_Vale_Prestamo == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Vale_Prestamo);
        }

        // GET: Detalle_Vale_Prestamo/Create
        public ActionResult Create()
        {
            ViewBag.id_prestamo = new SelectList(db.Vale_De_Prestamo, "id_prestamo", "Lugar");
            return View();
        }

        // POST: Detalle_Vale_Prestamo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_detalle_vale_prestamo,id_prestamo,id_inventario,cantidad")] Detalle_Vale_Prestamo detalle_Vale_Prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Detalle_Vale_Prestamo.Add(detalle_Vale_Prestamo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_prestamo = new SelectList(db.Vale_De_Prestamo, "id_prestamo", "Lugar", detalle_Vale_Prestamo.id_prestamo);
            return View(detalle_Vale_Prestamo);
        }

        // GET: Detalle_Vale_Prestamo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Vale_Prestamo detalle_Vale_Prestamo = db.Detalle_Vale_Prestamo.Find(id);
            if (detalle_Vale_Prestamo == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_prestamo = new SelectList(db.Vale_De_Prestamo, "id_prestamo", "Lugar", detalle_Vale_Prestamo.id_prestamo);
            return View(detalle_Vale_Prestamo);
        }

        // POST: Detalle_Vale_Prestamo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_detalle_vale_prestamo,id_prestamo,id_inventario,cantidad")] Detalle_Vale_Prestamo detalle_Vale_Prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_Vale_Prestamo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_prestamo = new SelectList(db.Vale_De_Prestamo, "id_prestamo", "Lugar", detalle_Vale_Prestamo.id_prestamo);
            return View(detalle_Vale_Prestamo);
        }

        // GET: Detalle_Vale_Prestamo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Vale_Prestamo detalle_Vale_Prestamo = db.Detalle_Vale_Prestamo.Find(id);
            if (detalle_Vale_Prestamo == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Vale_Prestamo);
        }

        // POST: Detalle_Vale_Prestamo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalle_Vale_Prestamo detalle_Vale_Prestamo = db.Detalle_Vale_Prestamo.Find(id);
            db.Detalle_Vale_Prestamo.Remove(detalle_Vale_Prestamo);
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

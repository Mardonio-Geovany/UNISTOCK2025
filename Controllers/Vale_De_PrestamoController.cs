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
    public class Vale_De_PrestamoController : Controller
    {
        private InventarioEntities db = new InventarioEntities();

        // GET: Vale_De_Prestamo
        public ActionResult Index()
        {
            return View(db.Vale_De_Prestamo.ToList());
        }

        // GET: Vale_De_Prestamo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vale_De_Prestamo vale_De_Prestamo = db.Vale_De_Prestamo.Find(id);
            if (vale_De_Prestamo == null)
            {
                return HttpNotFound();
            }
            return View(vale_De_Prestamo);
        }

        // GET: Vale_De_Prestamo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vale_De_Prestamo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_prestamo,Fecha_Emision,Lugar,Fecha_Devolucion,Descripcion_Articulo,Objetivo,NombreEntrega,NombreSolicitante")] Vale_De_Prestamo vale_De_Prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Vale_De_Prestamo.Add(vale_De_Prestamo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vale_De_Prestamo);
        }

        // GET: Vale_De_Prestamo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vale_De_Prestamo vale_De_Prestamo = db.Vale_De_Prestamo.Find(id);
            if (vale_De_Prestamo == null)
            {
                return HttpNotFound();
            }
            return View(vale_De_Prestamo);
        }

        // POST: Vale_De_Prestamo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_prestamo,Fecha_Emision,Lugar,Fecha_Devolucion,Descripcion_Articulo,Objetivo,NombreEntrega,NombreSolicitante")] Vale_De_Prestamo vale_De_Prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vale_De_Prestamo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vale_De_Prestamo);
        }

        // GET: Vale_De_Prestamo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vale_De_Prestamo vale_De_Prestamo = db.Vale_De_Prestamo.Find(id);
            if (vale_De_Prestamo == null)
            {
                return HttpNotFound();
            }
            return View(vale_De_Prestamo);
        }

        // POST: Vale_De_Prestamo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vale_De_Prestamo vale_De_Prestamo = db.Vale_De_Prestamo.Find(id);
            db.Vale_De_Prestamo.Remove(vale_De_Prestamo);
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

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
    public class Detalle_Vales_ResguardosController : Controller
    {
        private InventarioEntities db = new InventarioEntities();

        // GET: Detalle_Vales_Resguardos
        public ActionResult Index()
        {
            var detalle_Vales_Resguardos = db.Detalle_Vales_Resguardos.Include(d => d.Numero_Inventario).Include(d => d.Tabla_Resguardos);
            return View(detalle_Vales_Resguardos.ToList());
        }

        // GET: Detalle_Vales_Resguardos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Vales_Resguardos detalle_Vales_Resguardos = db.Detalle_Vales_Resguardos.Find(id);
            if (detalle_Vales_Resguardos == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Vales_Resguardos);
        }

        // GET: Detalle_Vales_Resguardos/Create
        public ActionResult Create()
        {
            ViewBag.id_inventario = new SelectList(db.Numero_Inventario, "id_numero_inventario", "numero_inventario1");
            ViewBag.id_resguardo = new SelectList(db.Tabla_Resguardos, "id_resguardo", "id_resguardo");
            return View();
        }

        // POST: Detalle_Vales_Resguardos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_detalle_vale_resguardo,id_resguardo,id_inventario,cantidad")] Detalle_Vales_Resguardos detalle_Vales_Resguardos)
        {
            if (ModelState.IsValid)
            {
                db.Detalle_Vales_Resguardos.Add(detalle_Vales_Resguardos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_inventario = new SelectList(db.Numero_Inventario, "id_numero_inventario", "numero_inventario1", detalle_Vales_Resguardos.id_inventario);
            ViewBag.id_resguardo = new SelectList(db.Tabla_Resguardos, "id_resguardo", "id_resguardo", detalle_Vales_Resguardos.id_resguardo);
            return View(detalle_Vales_Resguardos);
        }

        // GET: Detalle_Vales_Resguardos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Vales_Resguardos detalle_Vales_Resguardos = db.Detalle_Vales_Resguardos.Find(id);
            if (detalle_Vales_Resguardos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_inventario = new SelectList(db.Numero_Inventario, "id_numero_inventario", "numero_inventario1", detalle_Vales_Resguardos.id_inventario);
            ViewBag.id_resguardo = new SelectList(db.Tabla_Resguardos, "id_resguardo", "id_resguardo", detalle_Vales_Resguardos.id_resguardo);
            return View(detalle_Vales_Resguardos);
        }

        // POST: Detalle_Vales_Resguardos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_detalle_vale_resguardo,id_resguardo,id_inventario,cantidad")] Detalle_Vales_Resguardos detalle_Vales_Resguardos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_Vales_Resguardos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_inventario = new SelectList(db.Numero_Inventario, "id_numero_inventario", "numero_inventario1", detalle_Vales_Resguardos.id_inventario);
            ViewBag.id_resguardo = new SelectList(db.Tabla_Resguardos, "id_resguardo", "id_resguardo", detalle_Vales_Resguardos.id_resguardo);
            return View(detalle_Vales_Resguardos);
        }

        // GET: Detalle_Vales_Resguardos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Vales_Resguardos detalle_Vales_Resguardos = db.Detalle_Vales_Resguardos.Find(id);
            if (detalle_Vales_Resguardos == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Vales_Resguardos);
        }

        // POST: Detalle_Vales_Resguardos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Detalle_Vales_Resguardos detalle_Vales_Resguardos = db.Detalle_Vales_Resguardos.Find(id);
            db.Detalle_Vales_Resguardos.Remove(detalle_Vales_Resguardos);
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

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
    public class Tabla_ArticulosController : Controller
    {
        private InventarioEntities db = new InventarioEntities();

        // GET: Tabla_Articulos
        public ActionResult Index()
        {
            var tabla_Articulos = db.Tabla_Articulos.Include(t => t.Fuentes_Financiamiento);
            return View(tabla_Articulos.ToList());
        }

        // GET: Tabla_Articulos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabla_Articulos tabla_Articulos = db.Tabla_Articulos.Find(id);
            if (tabla_Articulos == null)
            {
                return HttpNotFound();
            }
            return View(tabla_Articulos);
        }

        // GET: Tabla_Articulos/Create
        public ActionResult Create()
        {
            ViewBag.id_fuente_financiamiento = new SelectList(db.Fuentes_Financiamiento, "id_fuente_financiamiento", "nombre_fuente");
            return View();
        }

        // POST: Tabla_Articulos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_articulo,descripcion,cantidad,marca,modelo,numero_serie,costo_adquisicion,fecha_adquisicion,id_fuente_financiamiento")] Tabla_Articulos tabla_Articulos)
        {
            if (ModelState.IsValid)
            {
                db.Tabla_Articulos.Add(tabla_Articulos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_fuente_financiamiento = new SelectList(db.Fuentes_Financiamiento, "id_fuente_financiamiento", "nombre_fuente", tabla_Articulos.id_fuente_financiamiento);
            return View(tabla_Articulos);
        }

        // GET: Tabla_Articulos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabla_Articulos tabla_Articulos = db.Tabla_Articulos.Find(id);
            if (tabla_Articulos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_fuente_financiamiento = new SelectList(db.Fuentes_Financiamiento, "id_fuente_financiamiento", "nombre_fuente", tabla_Articulos.id_fuente_financiamiento);
            return View(tabla_Articulos);
        }

        // POST: Tabla_Articulos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_articulo,descripcion,cantidad,marca,modelo,numero_serie,costo_adquisicion,fecha_adquisicion,id_fuente_financiamiento")] Tabla_Articulos tabla_Articulos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tabla_Articulos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_fuente_financiamiento = new SelectList(db.Fuentes_Financiamiento, "id_fuente_financiamiento", "nombre_fuente", tabla_Articulos.id_fuente_financiamiento);
            return View(tabla_Articulos);
        }

        // GET: Tabla_Articulos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabla_Articulos tabla_Articulos = db.Tabla_Articulos.Find(id);
            if (tabla_Articulos == null)
            {
                return HttpNotFound();
            }
            return View(tabla_Articulos);
        }

        // POST: Tabla_Articulos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tabla_Articulos tabla_Articulos = db.Tabla_Articulos.Find(id);
            db.Tabla_Articulos.Remove(tabla_Articulos);
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

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
    public class Numero_InventarioController : Controller
    {
        private InventarioEntities db = new InventarioEntities();

        // GET: Numero_Inventario
        public ActionResult Index()
        {
            var numero_Inventario = db.Numero_Inventario.Include(n => n.Tabla_Articulos);
            return View(numero_Inventario.ToList());
        }

        // GET: Numero_Inventario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Numero_Inventario numero_Inventario = db.Numero_Inventario.Find(id);
            if (numero_Inventario == null)
            {
                return HttpNotFound();
            }
            return View(numero_Inventario);
        }

        // GET: Numero_Inventario/Create
        public ActionResult Create()
        {
            ViewBag.id_articulo = new SelectList(db.Tabla_Articulos, "id_articulo", "descripcion");
            return View();
        }

        // POST: Numero_Inventario/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_numero_inventario,numero_inventario1,fecha_registro,id_articulo")] Numero_Inventario numero_Inventario)
        {
            if (ModelState.IsValid)
            {
                db.Numero_Inventario.Add(numero_Inventario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_articulo = new SelectList(db.Tabla_Articulos, "id_articulo", "descripcion", numero_Inventario.id_articulo);
            return View(numero_Inventario);
        }

        // GET: Numero_Inventario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Numero_Inventario numero_Inventario = db.Numero_Inventario.Find(id);
            if (numero_Inventario == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_articulo = new SelectList(db.Tabla_Articulos, "id_articulo", "descripcion", numero_Inventario.id_articulo);
            return View(numero_Inventario);
        }

        // POST: Numero_Inventario/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_numero_inventario,numero_inventario1,fecha_registro,id_articulo")] Numero_Inventario numero_Inventario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(numero_Inventario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_articulo = new SelectList(db.Tabla_Articulos, "id_articulo", "descripcion", numero_Inventario.id_articulo);
            return View(numero_Inventario);
        }

        // GET: Numero_Inventario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Numero_Inventario numero_Inventario = db.Numero_Inventario.Find(id);
            if (numero_Inventario == null)
            {
                return HttpNotFound();
            }
            return View(numero_Inventario);
        }

        // POST: Numero_Inventario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Numero_Inventario numero_Inventario = db.Numero_Inventario.Find(id);
            db.Numero_Inventario.Remove(numero_Inventario);
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

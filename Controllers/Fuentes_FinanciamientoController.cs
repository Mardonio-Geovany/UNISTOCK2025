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
    public class Fuentes_FinanciamientoController : Controller
    {
        private InventarioEntities db = new InventarioEntities();

        // GET: Fuentes_Financiamiento
        public ActionResult Index()
        {
            return View(db.Fuentes_Financiamiento.ToList());
        }

        // GET: Fuentes_Financiamiento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fuentes_Financiamiento fuentes_Financiamiento = db.Fuentes_Financiamiento.Find(id);
            if (fuentes_Financiamiento == null)
            {
                return HttpNotFound();
            }
            return View(fuentes_Financiamiento);
        }

        // GET: Fuentes_Financiamiento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fuentes_Financiamiento/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_fuente_financiamiento,nombre_fuente")] Fuentes_Financiamiento fuentes_Financiamiento)
        {
            if (ModelState.IsValid)
            {
                db.Fuentes_Financiamiento.Add(fuentes_Financiamiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fuentes_Financiamiento);
        }

        // GET: Fuentes_Financiamiento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fuentes_Financiamiento fuentes_Financiamiento = db.Fuentes_Financiamiento.Find(id);
            if (fuentes_Financiamiento == null)
            {
                return HttpNotFound();
            }
            return View(fuentes_Financiamiento);
        }

        // POST: Fuentes_Financiamiento/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_fuente_financiamiento,nombre_fuente")] Fuentes_Financiamiento fuentes_Financiamiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fuentes_Financiamiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fuentes_Financiamiento);
        }

        // GET: Fuentes_Financiamiento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fuentes_Financiamiento fuentes_Financiamiento = db.Fuentes_Financiamiento.Find(id);
            if (fuentes_Financiamiento == null)
            {
                return HttpNotFound();
            }
            return View(fuentes_Financiamiento);
        }

        // POST: Fuentes_Financiamiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fuentes_Financiamiento fuentes_Financiamiento = db.Fuentes_Financiamiento.Find(id);
            db.Fuentes_Financiamiento.Remove(fuentes_Financiamiento);
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

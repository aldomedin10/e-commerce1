using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using e_commerce1.Models;

namespace e_commerce1.Controllers
{
    public class ProductController : Controller
    {
        private e_tiendaEntities1 db = new e_tiendaEntities1();

        // GET: Product
        public ActionResult Index()
        {
            var producto = db.Producto.Include(p => p.Categoria).Include(p => p.Presentacion);
            return View(producto.ToList());
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.fk_categoria = new SelectList(db.Categoria, "Id", "Descripcion");
            ViewBag.Fk_Presentacion = new SelectList(db.Presentacion, "Id", "Tipo_Presentacion");
            return View();
        }

        // POST: Product/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Fk_Presentacion,Cantidad,Precio,Descripcion,Stock_Maximo,Stock_Minimo,Foto,fk_categoria")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.fk_categoria = new SelectList(db.Categoria, "Id", "Descripcion", producto.fk_categoria);
            ViewBag.Fk_Presentacion = new SelectList(db.Presentacion, "Id", "Tipo_Presentacion", producto.Fk_Presentacion);
            return View(producto);
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.fk_categoria = new SelectList(db.Categoria, "Id", "Descripcion", producto.fk_categoria);
            ViewBag.Fk_Presentacion = new SelectList(db.Presentacion, "Id", "Tipo_Presentacion", producto.Fk_Presentacion);
            return View(producto);
        }

        // POST: Product/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Fk_Presentacion,Cantidad,Precio,Descripcion,Stock_Maximo,Stock_Minimo,Foto,fk_categoria")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.fk_categoria = new SelectList(db.Categoria, "Id", "Descripcion", producto.fk_categoria);
            ViewBag.Fk_Presentacion = new SelectList(db.Presentacion, "Id", "Tipo_Presentacion", producto.Fk_Presentacion);
            return View(producto);
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Producto.Find(id);
            db.Producto.Remove(producto);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IngresosGastos.Data;
using IngresosGastos.Models;

namespace IngresosGastos.Controllers
{
    public class IngresosGastosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: IngresosGastos
        public ActionResult Index()
        {
            double ingresos, gastos, neto;

            ingresos = db.IngresosGastos.Where(m => m.EsIngreso == true).Select(p => p.Valor).DefaultIfEmpty(0.0).Sum();
            gastos= db.IngresosGastos.Where(m => m.EsIngreso == false).Select(p => p.Valor).DefaultIfEmpty(0.0).Sum();
            neto = ingresos - gastos;
            ViewBag.Ingresos = ingresos;
            ViewBag.Egresos = gastos;
            ViewBag.Neto = neto;


            return View(db.IngresosGastos.ToList());
        }

        // GET: IngresosGastos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngresosGastosMMu ingresosGastosMMu = db.IngresosGastos.Find(id);
            if (ingresosGastosMMu == null)
            {
                return HttpNotFound();
            }
            return View(ingresosGastosMMu);
        }

        // GET: IngresosGastos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IngresosGastos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,EsIngreso,Valor")] IngresosGastosMMu ingresosGastosMMu)
        {
            if (ModelState.IsValid)
            {
                ingresosGastosMMu.FechaIngreso = DateTime.Now;
                db.IngresosGastos.Add(ingresosGastosMMu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingresosGastosMMu);
        }

        // GET: IngresosGastos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngresosGastosMMu ingresosGastosMMu = db.IngresosGastos.Find(id);
            if (ingresosGastosMMu == null)
            {
                return HttpNotFound();
            }
            return View(ingresosGastosMMu);
        }

        // POST: IngresosGastos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,EsIngreso,Valor")] IngresosGastosMMu ingresosGastosMMu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingresosGastosMMu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingresosGastosMMu);
        }

        // GET: IngresosGastos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngresosGastosMMu ingresosGastosMMu = db.IngresosGastos.Find(id);
            if (ingresosGastosMMu == null)
            {
                return HttpNotFound();
            }
            return View(ingresosGastosMMu);
        }

        // POST: IngresosGastos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IngresosGastosMMu ingresosGastosMMu = db.IngresosGastos.Find(id);
            db.IngresosGastos.Remove(ingresosGastosMMu);
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

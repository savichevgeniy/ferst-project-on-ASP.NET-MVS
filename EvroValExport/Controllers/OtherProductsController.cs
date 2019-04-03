using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EvroValExport.Models;

namespace EvroValExport.Controllers
{
    public class OtherProductsController : Controller
    {
        private UserContext db = new UserContext();

        [HttpGet]
        [Authorize(Users = "Разработчик,Директор,Инженер,Бухгалтер")]
        public ActionResult Index(OtherProducts otherProducts)
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(string filter)
        {
            ViewBag.filter = filter;
            return View();
        }

        public ActionResult GetOtherProducts(string filter = null)
        {
            IEnumerable<OtherProducts> otherProducts = db.OtherProducts;
            {
            }
            return View("_TableOtherProducts", filter == null ? otherProducts : otherProducts.Where(p => p.Name.Contains(filter)));
        }


        [Authorize(Users = "Разработчик,Директор,Инженер,Бухгалтер")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherProducts otherProducts = db.OtherProducts.Find(id);
            if (otherProducts == null)
            {
                return HttpNotFound();
            }
            return View(otherProducts);
        }


        [Authorize(Users = "Разработчик,Инженер,Бухгалтер")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: OtherProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Category,Material,Price,Quantity")] OtherProducts otherProducts)
        {
            if (ModelState.IsValid)
            {
                db.OtherProducts.Add(otherProducts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(otherProducts);
        }


        [Authorize(Users = "Разработчик,Инженер,Бухгалтер")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherProducts otherProducts = db.OtherProducts.Find(id);
            if (otherProducts == null)
            {
                return HttpNotFound();
            }
            return View(otherProducts);
        }

        // POST: OtherProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Category,Material,Price,Quantity")] OtherProducts otherProducts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(otherProducts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(otherProducts);
        }

        // GET: OtherProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OtherProducts otherProducts = db.OtherProducts.Find(id);
            if (otherProducts == null)
            {
                return HttpNotFound();
            }
            return View(otherProducts);
        }


        [Authorize(Users = "Разработчик,Инженер,Бухгалтер")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OtherProducts otherProducts = db.OtherProducts.Find(id);
            db.OtherProducts.Remove(otherProducts);
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

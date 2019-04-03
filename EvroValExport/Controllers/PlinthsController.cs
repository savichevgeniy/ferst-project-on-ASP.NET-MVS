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
    public class PlinthsController : Controller
    {
        private UserContext db = new UserContext();


        [HttpGet]
        [Authorize(Users = "Разработчик,Директор,Инженер,Бухгалтер")]
        public ActionResult Index(Plinth  plinth)
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(string filter)
        {
            ViewBag.filter = filter;
            return View();
        }

        public ActionResult GetPlinths(string filter = null)
        {
            IEnumerable<Plinth> plinths = db.Plinths;
            {
            }
            return View("_TablePlinths", filter == null ? plinths : plinths.Where(p => p.Name.Contains(filter)));
        }


        [Authorize(Users = "Разработчик,Директор,Инженер,Бухгалтер")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plinth plinth = db.Plinths.Find(id);
            if (plinth == null)
            {
                return HttpNotFound();
            }
            return View(plinth);
        }


        [Authorize(Users = "Разработчик,Инженер,Бухгалтер")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plinths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Category,Material,Price,Quantity")] Plinth plinth)
        {
            if (ModelState.IsValid)
            {
                db.Plinths.Add(plinth);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plinth);
        }


        [Authorize(Users = "Разработчик,Инженер,Бухгалтер")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plinth plinth = db.Plinths.Find(id);
            if (plinth == null)
            {
                return HttpNotFound();
            }
            return View(plinth);
        }

        // POST: Plinths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Category,Material,Price,Quantity")] Plinth plinth)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plinth).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plinth);
        }


        [Authorize(Users = "Разработчик,Инженер,Бухгалтер")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plinth plinth = db.Plinths.Find(id);
            if (plinth == null)
            {
                return HttpNotFound();
            }
            return View(plinth);
        }

        // POST: Plinths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plinth plinth = db.Plinths.Find(id);
            db.Plinths.Remove(plinth);
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

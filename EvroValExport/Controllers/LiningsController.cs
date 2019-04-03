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
    public class LiningsController : Controller
    {
        private UserContext db = new UserContext();

        
        [HttpGet]
        [Authorize(Users = "Разработчик,Директор,Инженер,Бухгалтер")]
        public ActionResult Index(Lining linings)
        { 
            return View();
        }
        [HttpPost]
        public ActionResult Index(string filter)
        {
            ViewBag.filter = filter;
            return View();
        }

        public ActionResult GetLinings(string filter = null)
        {
            IEnumerable<Lining> linings = db.Linings;
            {
            }
            return View("_TableLinings", filter == null ? linings : linings.Where(p => p.Name.Contains(filter)));
        }


        [Authorize(Users = "Разработчик,Директор,Инженер,Бухгалтер")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lining lining = db.Linings.Find(id);
            if (lining == null)
            {
                return HttpNotFound();
            }
            return View(lining);
        }


        [Authorize(Users = "Разработчик,Инженер,Бухгалтер")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Linings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Category,Material,Price,Quantity")] Lining lining)
        {
            if (ModelState.IsValid)
            {
                db.Linings.Add(lining);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lining);
        }


        [Authorize(Users = "Разработчик,Инженер,Бухгалтер")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lining lining = db.Linings.Find(id);
            if (lining == null)
            {
                return HttpNotFound();
            }
            return View(lining);
        }

        // POST: Linings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Category,Material,Price,Quantity")] Lining lining)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lining).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lining);
        }


        [Authorize(Users = "Разработчик,Инженер,Бухгалтер")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lining lining = db.Linings.Find(id);
            if (lining == null)
            {
                return HttpNotFound();
            }
            return View(lining);
        }


      
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lining lining = db.Linings.Find(id);
            db.Linings.Remove(lining);
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

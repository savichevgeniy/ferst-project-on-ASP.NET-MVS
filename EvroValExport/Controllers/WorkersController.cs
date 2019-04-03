using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EvroValExport.Models;
using FormsAuthApp.Models;

namespace EvroValExport.Controllers
{
    public class WorkersController : Controller
    {
        private UserContext db = new UserContext();

        [HttpGet]
        [Authorize(Users = "Разработчик,Директор,Инженер,Бухгалтер")]
        public ActionResult Index(Workers workers)
        {
                    
            return View();
        }

        [HttpGet]
        [Authorize(Users = "Вахтер")]
        public ActionResult Watch(Workers workers)
        {

            return View();
        }

        [HttpGet]
        [Authorize(Users = "Вахтер,Бухгалтер,Директор,Разработчик")]
        public ActionResult Work(Workers workers)
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(string filter)
        {
            ViewBag.filter = filter;
            return View();
            
        }

        public ActionResult GetWorkers (string filter = null)
        {
            IEnumerable<Workers> workers = db.Workers;
            { 
}
            return View("_TableWorkers", filter == null ? workers : workers.Where(p => p.FIO.Contains(filter)));
        }



        public ActionResult GetWatch(string filter = null)
        {
            IEnumerable<Workers> workers = db.Workers;
            {
            }
            return View("_TableWatch", filter == null ? workers : workers.Where(p => p.FIO.Contains(filter)));
        }


        public ActionResult GetWork(string filter = null)
        {
            IEnumerable<Workers> workers = db.Workers;
            {
            }
            return View("_TableWork", filter == null ? workers : workers.Where(p => p.Position.Contains(filter)));
        }



        [Authorize(Users = "Разработчик,Инженер,Бухгалтер")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workers workers = db.Workers.Find(id);
            if (workers == null)
            {
                return HttpNotFound();
            }
            return View(workers);
        }

        [Authorize(Users = "Разработчик,Инженер,Бухгалтер")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Workers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FIO,Address,Phone,Position,SumWork,StartTime,EndTime,CurrentTime")] Workers workers)
        {
            if (ModelState.IsValid)
            {
                db.Workers.Add(workers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workers);
        }




        [Authorize(Users = "Разработчик,Инженер,Бухгалтер")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workers workers = db.Workers.Find(id);
            if (workers == null)
            {
                return HttpNotFound();
            }
            return View(workers);
        }

        // POST: Workers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FIO,Address,Phone,Position,SumWork,StartTime,EndTime,CurrentTime")] Workers workers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workers);
        }



        [Authorize(Users = "Вахтер")]
        public ActionResult WatchEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workers workers = db.Workers.Find(id);
            if (workers == null)
            {
                return HttpNotFound();
            }
            
            return View(workers);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WatchEdit([Bind(Include = "Id, FIO, Address, Phone, Position, SumWork, StartTime, EndTime, CurrentTime")] Workers workers)
        {
            
            if (ModelState.IsValid)
            {
                db.Entry(workers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Watch");
            }
            return View(workers);
        }



        [Authorize(Users = "Бухгалтер,Директор,Разработчик")]
        public ActionResult WorkEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workers workers = db.Workers.Find(id);
            if (workers == null)
            {
                return HttpNotFound();
            }

            return View(workers);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WorkEdit([Bind(Include = "Id, FIO, Address, Phone, Position, SumWork, StartTime, EndTime, CurrentTime")] Workers workers)
        {

            if (ModelState.IsValid)
            {
                db.Entry(workers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Work");
            }
            return View(workers);
        }


        [Authorize(Users = "Разработчик,Инженер,Бухгалтер")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workers workers = db.Workers.Find(id);
            if (workers == null)
            {
                return HttpNotFound();
            }
            return View(workers);
        }

        // POST: Workers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Workers workers = db.Workers.Find(id);
            db.Workers.Remove(workers);
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

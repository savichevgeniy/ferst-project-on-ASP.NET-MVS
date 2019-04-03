using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EvroValExport.Models;



namespace EvroValExport.Controllers
{
    public class HomeController : Controller
    {

       


        [Authorize(Users = "Разработчик,Директор,Инженер,Бухгалтер")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Users = "Разработчик,Директор,Инженер,Бухгалтер,Работник,Вахтер")]
        public ActionResult Reference()
        {
            return View();
        }

        [Authorize(Users = "Разработчик,Директор,Инженер,Бухгалтер,Работник,Вахтер")]
        public ActionResult About()
        {
            ViewBag.Message = "Страница описания предприятия";

            return View();
        }

        [Authorize(Users = "Разработчик,Директор,Инженер,Бухгалтер,Работник,Вахтер")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Страница с контактными данными предприятия";

            return View();
        }

        


        UserContext db = new UserContext();

        [Authorize(Users = "Разработчик,Директор,Инженер,Бухгалтер,Работник,Вахтер")]
        public ActionResult News()
        {
            ViewBag.Message = "Страница новостей";

            return View(db.News);
        }

        [Authorize(Users = "Разработчик,Директор,Инженер,Бухгалтер")]
        public ActionResult Linings()
        {
            return View(db.Linings);
        }


        [Authorize(Users = "Разработчик,Директор,Инженер,Бухгалтер")]
        public ActionResult OtherProducts()
        {
            return View(db.OtherProducts );
        }

        [Authorize(Users = "Разработчик,Директор,Инженер,Бухгалтер")]
        public ActionResult Plinths()
        {
            return View(db.Plinths );
        }



        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
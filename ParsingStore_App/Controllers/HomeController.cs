using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ParsingStore_App.DAL;

namespace ParsingStore_App.Controllers
{
    public class HomeController : Controller
    {
        private ProductContext db = new ProductContext();

        public ActionResult Index()
        {
            var test =  db.Site.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
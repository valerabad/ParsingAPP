using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParsingStore_App.Models;
using System.Web.Mvc;
using ParsingStore_App.ParserManager;
using ParsingStore_App.DAL;

namespace ParsingStore_App.Controllers
{
    public class ParsePageController : Controller
    {
        ProductContext dbContext = new ProductContext();
        // GET: ParsePage
        public ActionResult Index()
        {


            SelectList sites = new SelectList(dbContext.Site, "Id", "Name");
            ViewBag.sites  = sites;

            SelectList products = new SelectList(dbContext.Product, "Id", "ProdName");
            ViewBag.products = products;
           
            return View();
        }

        //[HttpPost]
        public ActionResult ParsingAction()
        {
            return View();
        }
    }
}
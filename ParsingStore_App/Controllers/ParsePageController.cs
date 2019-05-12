using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParsingStore_App.Models;
using System.Web.Mvc;
using ParsingStore_App.ParserManager;

namespace ParsingStore_App.Controllers
{
    public class ParsePageController : Controller
    {
        // GET: ParsePage
        public ActionResult Index()
        {
            // как то получаем из формы значение выбрынных пользователем параметров
            Site site = null;
            ProductShoes parsedProduct = null;

            ParsingManger parsingManager = new ParsingManger();
            Product product = parsingManager.ParsePage(site, parsedProduct);


            return View();
        }
    }
}
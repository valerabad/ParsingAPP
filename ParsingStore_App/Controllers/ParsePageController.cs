using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ParsingStore_App.Models;
using System.Web.Mvc;
using ParsingStore_App.ParserManager;
using ParsingStore_App.DAL;
using System.Net;

namespace ParsingStore_App.Controllers
{
    public class ParsePageController : Controller
    {
        ProductContext dbContext = new ProductContext();
        // GET: ParsePage
        //public ActionResult Index()
        public ActionResult ParsingAction()
        {
            int id = 1;
            SelectList sites = new SelectList(dbContext.Site, "Id", "Name");
            ViewBag.sites  = sites;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Site site_ = dbContext.Site.Find(id);
            if (site_ == null)
            {
                return HttpNotFound();
            }
            return View(site_);

            //SelectList products = new SelectList(dbContext.Product, "Id", "ProdName");
            //ViewBag.products = products;

            //return View();
        }

        [HttpPost]
        public ActionResult ParsingAction(Site site)
        {
            string SelectedValue = site.Name;
            return View(site);
            //Request.Form["ddlVendor"].ToString();
            //return View();
        }
    }
}
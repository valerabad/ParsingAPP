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

        [HttpGet]
        public ActionResult GetProductForParsing()
        {
            ViewModelSiteProduct model = new ViewModelSiteProduct();
            model.allSites = new Site();
            model.allSites.Sites = PopulateSites();
            model.allProducts = new Product();
            model.allProducts.Products = new List<SelectListItem>() { new SelectListItem
                {
                    Text = "choose site",
                    Value = "choose site"
                } };
            //ViewModelSiteProduct vmDemo = new ViewModelSiteProduct();
            //vmDemo.allProducts = dbContext.Product.ToList();
            //vmDemo.allSites = dbContext.Site.ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult GetProductForParsing(ViewModelSiteProduct site)
        {           
            site.allSites.Sites = PopulateSites();
            var selectedItem = site.allSites.Sites.Find(x=>x.Value==site.allSites.Id.ToString());
            var v1 = selectedItem.Text;

            List<Product> reesProd = dbContext.Product.ToList().FindAll(x => x.Siteid.ToString() == selectedItem.Value);

            site.allProducts.Products = PopulateProducts(selectedItem.Value);

            //var enabledProducts = site.allProducts.Products.Find(x => x.Value == site.allSites.Id.ToString());

            return View(site);
        }

        [HttpPost]    
        public void GetParsedProduct(ViewModelSiteProduct site)
        {
            // View(site); 
        }


        private List<SelectListItem> PopulateProducts(string siteID)
        {
            List<SelectListItem> items = new List<SelectListItem>();            
            List<Product> reesProd = dbContext.Product.ToList().FindAll(x => x.Siteid.ToString() == siteID);
            foreach (var item in reesProd)
            {
                items.Add(new SelectListItem
                {
                    Text = item.ProdName,
                    Value = item.Id.ToString()
                });
            }

            return items;
        }

        private  List<SelectListItem> PopulateSites()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            List<Site> lst = dbContext.Site.ToList();
            foreach (var item in lst)
            {
                items.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }

            return items;
        }
    }
}   
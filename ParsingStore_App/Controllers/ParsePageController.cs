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
            ViewBag.sites = sites;

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
            var selectedItem = site.allSites.Sites.Find(x => x.Value == site.allSites.Id.ToString());
            var v1 = selectedItem.Text;

            List<Product> reesProd = dbContext.Product.ToList().FindAll(x => x.Siteid.ToString() == selectedItem.Value);

            site.allProducts.Products = PopulateProducts(selectedItem.Value);

            //var selectedProd = 

            return View(site);
        }

        [HttpGet]
        public ActionResult GetParsedProduct(ViewModelSiteProduct site)
        {
            ParsedProduct pp = new ParsedProduct() { Id = 1, Title = "testTitle", Price = "5", Description = "testDesc" };
            List<ParsedProduct> listPP = new List<ParsedProduct>();
            listPP.Add(pp);
            return View(listPP);
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

        private List<SelectListItem> PopulateSites()
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

        [HttpGet]
        public ActionResult Parse()
        {
            //SelectList
            try
            {
                string strDDLValue = Request.QueryString["SitesList"].ToString();                
                string strDDLValu3 = Request.QueryString["ProductsList"].ToString();
            }
            //SelectList selectList = dbContext.Site.
            catch (Exception ex)
            {

            }

           SelectList sl = new SelectList( dbContext.Site.ToList(), "Id", "Name");
           SelectList pr = new SelectList(dbContext.Product.ToList(), "Id", "ProdName");


            List<SelectListItem> prodList = new List<SelectListItem>()
            {
                 new SelectListItem { Text = "Choose site" },                
            };        

            ViewBag.SitesList = sl;
            ViewBag.ProductsList = pr;

            return View();
        }

        [HttpPost, ActionName("Parse")]
        public ActionResult ParseGetData()
        {
            string strDDLValue1 = null;
            string strDDLValue2 = null;
            // or using QueryString
            try
            {
                strDDLValue1 = Request.Form["SitesList"].ToString();
                strDDLValue2 = Request.Form["ProductsList"].ToString();
            }
            catch (Exception ex) { }

            Site selectedSite = dbContext.Site.ToList().Find(x => x.Id .ToString() == strDDLValue1);
            Product selectedProduct = dbContext.Product.ToList().Find(x => x.Id.ToString() == strDDLValue2);

            ViewBag.Prods = selectedProduct;

            //parse site and populate db
            if ((selectedSite.Name == "badminton.ua") || (selectedProduct.ProdName == "Shoes"))
            {
                IProductXPath prodShoes = new ProductTemaplates.Shoes();
                //string html = HttpService.LoadHTMLPage(selectedSite);

                List<ParsedProduct> psrsedShoesList = ParsingManger.GetProducts(selectedSite, prodShoes);
                foreach(ParsedProduct product in psrsedShoesList)
                {
                    ParsingManger.SaveProductToDB(product, dbContext);
                    dbContext.SaveChanges();
                }               
            }


            return RedirectToAction("ParsedProductTable");
        }

        [HttpGet]
        public ActionResult ParsedProductTable()
        {
            return View(dbContext.ParsedProduct.ToList());
        }
    }
}
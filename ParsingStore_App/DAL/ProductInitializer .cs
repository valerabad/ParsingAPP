using System;
using System.Collections.Generic;
using ParsingStore_App.Models;
using System.Data.Entity;

namespace ParsingStore_App.DAL
{
    public class ProductInitializer : DropCreateDatabaseAlways<ProductContext> //DropCreateDatabaseIfModelChanges
    {
        public string GetAllSites()
        {
            // заглушка для теста
            return "";
        }

        public Product GetProductbySite(string siteUrl)
        {
            return new Product();
        }

        public void SaveProductToDB(Product product)
        {

        }

        protected override void Seed(ProductContext context)
        {
            Site site1 = new Site() { Name="badminton.ua", Url= "https://badminton.ua/product/category/krossovki-dlya-badmintona/krossovki-fz-forza/" };
            Site site2 = new Site() { Name = "badminton.ua", Url = "https://badminton.ua/product/category/raketki/" };

            Product product = new Product() { Title = "Shoes" };

            context.Site.Add(site1);
            context.Site.Add(site2);
            context.SaveChanges();

            string selectedSiteUrl = GetAllSites();
            Product selectedProduct = GetProductbySite(selectedSiteUrl);
            
            //SaveProductToDB();

        }
    }
    }
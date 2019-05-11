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
            return "https://badminton.ua/product/category/krossovki-dlya-badmintona/krossovki-fz-forza/";
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
            string selectedSiteUrl = GetAllSites();
            Product selectedProduct = GetProductbySite(selectedSiteUrl);            

            SaveProductToDB();

        }
    }
    }
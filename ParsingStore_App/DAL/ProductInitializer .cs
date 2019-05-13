using System;
using System.Collections.Generic;
using ParsingStore_App.Models;
using System.Data.Entity;

namespace ParsingStore_App.DAL
{
    public class ProductInitializer : DropCreateDatabaseAlways<ProductContext> //DropCreateDatabaseIfModelChanges
    {       
        protected override void Seed(ProductContext context)
        {
            Site site1 = new Site() { Name="badminton.ua", Url= "https://badminton.ua/product/category/krossovki-dlya-badmintona/krossovki-fz-forza/" };
            Site site2 = new Site() { Name = "allo.ua", Url = "https://allo.ua/ru/products/mobile/proizvoditel-xiaomi/" };           

            context.Site.Add(site1);
            context.Site.Add(site2);
            context.SaveChanges();

            Product product1 = new Product() { ProdName = "badminton.ua/shoes", Siteid = 1 };
            Product product2 = new Product() { ProdName = "badminton.ua/rackets", Siteid = 1 };
            Product product3 = new Product() { ProdName = "allo.ua/mobile", Siteid = 2 };
            Product product4 = new Product() { ProdName = "allo.ua/pc", Siteid = 2 };
            context.Product.Add(product1);
            context.Product.Add(product2);

            context.SaveChanges();

        }
    }
    }
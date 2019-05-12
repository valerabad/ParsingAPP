﻿using System;
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
            Site site2 = new Site() { Name = "badminton.ua", Url = "https://badminton.ua/product/category/raketki/" };

            ParsedProduct product1 = new ParsedProduct() { ProdName = "Shoes", Siteid = site1.Id };
            ParsedProduct product2 = new ParsedProduct() { ProdName = "Rackets", Siteid = site1.Id };

            context.Site.Add(site1);
            context.Site.Add(site2);
            context.ParsedProduct.Add(product1);
            context.ParsedProduct.Add(product2);

            context.SaveChanges();

        }
    }
    }
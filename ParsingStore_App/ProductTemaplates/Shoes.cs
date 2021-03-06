﻿using ParsingStore_App.ParserManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParsingStore_App.ProductTemaplates
{
    public class Shoes : IProductXPath
    {
        public string TargetProduct { get; } = "Shoes";
        public string TitleXPath { get; } = ".//h3[@class='content-product__name-heading']/a";
        public string PriseXPath { get; } = ".//div[@class='content-product__price']//div[@class='product-price']//" +
               "span[@class='wc-price wc-price-on-sale wc-price-variable']";
        public string DescriptionXPath { get; } = "";
        public string ImageXPath { get; } = ".//div[@class='content-product__thumb']//a//img";
    }
}
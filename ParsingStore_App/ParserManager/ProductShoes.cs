using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParsingStore_App.ParserManager
{
    public class ProductShoes
    {
        public string TargetProduct { get; set; } = "Shoes";
        public string TitleXPath { get; set; } = "//div";
        public string PriseXPath { get; set; } = "//div";
        public string DescriptionXPath { get; set; } = "//div";
        public string ImageXPath { get; set; } = "//div";
    }
}

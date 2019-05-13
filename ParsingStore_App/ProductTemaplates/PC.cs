using ParsingStore_App.ParserManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParsingStore_App.ProductTemaplates
{
    public class PC : IProductXPath
    {
        public string TargetProduct { get; } = "PC";
        public string TitleXPath { get; } = "";
        public string PriseXPath { get; } = "";
        public string DescriptionXPath { get; } = "";
        public string ImageXPath { get; } = "";
    }
}
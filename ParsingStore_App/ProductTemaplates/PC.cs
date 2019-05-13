using ParsingStore_App.ParserManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParsingStore_App.ProductTemaplates
{
    public class PC : IProducXPath
    {
        public string TargetProduct { get; set; }
        public string TitleXPath { get; set; }
        public string PriseXPath { get; set; }
        public string DescriptionXPath { get; set; }
        public string ImageXPath { get; set; }
    }
}
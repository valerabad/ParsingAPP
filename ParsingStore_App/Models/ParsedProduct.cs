using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParsingStore_App.Models
{
    [Table("ParsedProduct")]
    public class ParsedProduct
    {
        public int Id { get; set; }
        public string Siteid { get; set; }
        public string Prodid { get; set; }

        public string TargetProduct { get; set; } = "Shoes";
        public string TitleXPath { get; set; } = "//div";
        public string PriseXPath { get; set; } = "//div";
        public string DescriptionXPath { get; set; } = "//div";
        public string ImageXPath { get; set; } = "//div";        
    }
}

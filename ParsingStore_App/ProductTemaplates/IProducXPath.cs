using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParsingStore_App.ParserManager
{
    public interface IProducXPath
    {
        string TargetProduct { get; set; }
        string TitleXPath { get; set; } 
        string PriseXPath { get; set; } 
        string DescriptionXPath { get; set; } 
        string ImageXPath { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParsingStore_App.ParserManager
{
    public interface IProductXPath
    {
        string TargetProduct { get; }
        string TitleXPath { get; } 
        string PriseXPath { get; } 
        string DescriptionXPath { get; } 
        string ImageXPath { get; }
    }
}

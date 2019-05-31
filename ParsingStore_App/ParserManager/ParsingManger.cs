using HtmlAgilityPack;
using ParsingStore_App.Models;
using ParsingStore_App.ParserManager;
using System.IO;
using System.Net;
using System.Text;
using System;
using ParsingStore_App.DAL;
using System.Collections.Generic;

namespace ParsingStore_App
{
    public class ParsingManger
    {                
        static public List<ParsedProduct> GetProducts(Site site, IProductXPath productForParsing)
        {
            string HTMLPage = HttpService.LoadHTMLPage(site);
            List<ParsedProduct> resultProduct = Parser.GetParsedProduct(HTMLPage, productForParsing);           

            return resultProduct;
        }                

        static public void SaveProductToDB(ParsedProduct product, ProductContext context)
        {
            context.ParsedProduct.Add(product);
        }


    }
}
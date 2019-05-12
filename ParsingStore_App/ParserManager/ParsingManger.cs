using HtmlAgilityPack;
using ParsingStore_App.Models;
using ParsingStore_App.ParserManager;
using System.IO;
using System.Net;
using System.Text;
using System;
using ParsingStore_App.DAL;

namespace ParsingStore_App
{
    public class ParsingManger
    {                
        public Product GetProducts(Site site, ProductShoes productForParsing)
        {
            Parser parser = new Parser();
            Product resultProduct = parser.ParsePage(site, productForParsing);

            return resultProduct;
        }                

        public void SaveProductToDB(Product product, ProductContext context)
        {
            context.Product.Add(product);
        }


    }
}
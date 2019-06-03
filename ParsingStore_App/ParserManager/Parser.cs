using HtmlAgilityPack;
using ParsingStore_App.Models;
using ParsingStore_App.ParserManager;
using System.IO;
using System.Net;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace ParsingStore_App.ParserManager
{
    static public class Parser
    {        
        static public List<ParsedProduct> GetParsedProduct(string HTML, IProductXPath parsedProduct)
        {
            List<ParsedProduct> parsedProductList = new List<ParsedProduct>();
            var document = new HtmlDocument();
            document.LoadHtml(HTML);
            string title = null;

            // parse product title            
            HtmlNodeCollection titleNodes = document.DocumentNode.SelectNodes(parsedProduct.TitleXPath); //".//h3[@class='content-product__name-heading']/a"
            foreach (HtmlNode titleProd in titleNodes)
            {
                title = titleProd.GetAttributeValue("title", null);
                ParsedProduct resultProduct = new ParsedProduct { Title = title };
                parsedProductList.Add(resultProduct);
            }


            // parse product Price
            HtmlNodeCollection prices = document.DocumentNode.SelectNodes
               (".//div[@class='content-product__price']//div[@class='product-price']//" +
               "span[@class='wc-price wc-price-on-sale wc-price-variable']"); //  //span[@class='wc-price-sale']//span[@class='wc-price-number'] 
            int j = 0;

            int n = 0;
            foreach (HtmlNode price in prices)
            {
                if (price != null)
                {
                    string decodedString = price.InnerText.Replace("&nbsp; &#8372;", " грн."); // ₴InnerText = "\n            от 2 619&nbsp; &#8372;        "
                    decodedString = decodedString.Replace("  ", string.Empty);
                    decodedString = decodedString.Replace("\n", string.Empty);
                    //productList.ElementAt(j++).Price = (decodedString);


                    parsedProductList.ElementAt(n++).Price = decodedString;

                }
            }


            // parce product image .//li//div[@class='content-product__thumb']//a//img
            HtmlNodeCollection imgs = document.DocumentNode.SelectNodes
              (".//div[@class='content-product__thumb']//a//img"); //content - product__thumb
            int k = 0;
            foreach (HtmlNode imgUrl in imgs)
            {
                string urlImage = imgUrl.Attributes["data-srcset"].Value;// ("DeEntitizeValue", null);// DeEntitizeValue = "https://badminton.ua/wp-content/themes/badminton/public/img/logo/logo-icon.png"
                string[] arr_Url = urlImage.Split(' ');
                urlImage = arr_Url[0];
                if (urlImage != null)
                {
                    Image imageCurProd = DownloadImageByUrl(urlImage);
                    byte[] bytesArrForImage = imageToByteArray(imageCurProd);
                    //productList.ElementAt(k++).ImageBytes = bytesArrForImage.Select(a=>(byte?)a).ToArray();
                    parsedProductList.ElementAt(k++).ImageBytes = bytesArrForImage;
                }


            }


            return parsedProductList;
        }

        public static Image DownloadImageByUrl(string imageUrl)
        {
            Image image = null;
            try
            {
                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.
                    Create(imageUrl);
                webRequest.AllowWriteStreamBuffering = true;
                webRequest.Timeout = 30000;

                System.Net.WebResponse webResponse = webRequest.GetResponse();

                System.IO.Stream stream = webResponse.GetResponseStream();

                image = System.Drawing.Image.FromStream(stream);

                webResponse.Close();
            }
            catch (Exception ex)
            {
                return null;
            }

            return image;
        }

        static private byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return (ms.ToArray());
        }
    }
}
﻿using HtmlAgilityPack;
using ParsingStore_App.Models;
using ParsingStore_App.ParserManager;
using System.IO;
using System.Net;
using System.Text;
using System;

namespace ParsingStore_App.ParserManager
{
    static public class Parser
    {
        static public string ParsePage(Site site)
        {
            string HTML = LoadHTMLPage(site);            
            return HTML;
        }

        static public ParsedProduct GetParsedProduct(string HTML, ProductShoes parsedProduct)
        {
            var document = new HtmlDocument();
            document.LoadHtml(HTML);
            string title = null;

            // parse product title
            HtmlNodeCollection titleNodes = document.DocumentNode.SelectNodes(parsedProduct.TitleXPath); //     ".//h3[@class='content-product__name-heading']/a"
            foreach (HtmlNode titleProd in titleNodes)
            {
                title = titleProd.GetAttributeValue("title", null);
                break;
            }
            ParsedProduct resultProduct = new ParsedProduct { Title = title };
            return resultProduct;
        }

        static private string LoadHTMLPage(Site site)
        {
            var result = "";
            var request = (HttpWebRequest)WebRequest.Create(site.Url); // URL
            var response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var receiveStream = response.GetResponseStream();
                if (receiveStream != null)
                {
                    StreamReader readStream;
                    if (response.CharacterSet == null)
                        readStream = new StreamReader(receiveStream);

                    else
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    result = readStream.ReadToEnd();
                    readStream.Close();
                }
                response.Close();
            }
            return result;
        }

        static private byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return (ms.ToArray());
        }
    }
}
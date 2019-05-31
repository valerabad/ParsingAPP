using ParsingStore_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParsingStore_App.DAL
{
    [Table("ViewModelSite")]
    public class ViewModelSiteProduct
    {
        public int Id { get; set; }
        public Site allSites { get; set; }
        public Product allProducts { get; set; }

        //[NotMapped]
        //public List<SelectListItem> Sites { get; set; }
    }
}
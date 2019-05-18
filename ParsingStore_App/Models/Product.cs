using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ParsingStore_App.Models
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        public int Siteid { get; set; }
        public string ProdName { get; set; }

        [NotMapped]
        public List<SelectListItem> Products { get; set; }

        //reference to Product class
        public Site Site { get; set; }
    }
}
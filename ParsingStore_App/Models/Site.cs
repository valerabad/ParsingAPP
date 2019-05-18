using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace ParsingStore_App.Models
{
    [Table("Site")]
    public class Site
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        [NotMapped]
        public List<SelectListItem> Sites { get; set; }
        //[NotMapped]        
        //reference to Product class
        public List<Product> Products { get; set; }
    }
}
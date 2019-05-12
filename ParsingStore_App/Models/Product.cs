using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParsingStore_App.Models
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        public int Siteid { get; set; }
        public string ProdName { get; set; }                   
    }
}
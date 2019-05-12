using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParsingStore_App.Models
{
    [Table("ParsedProduct")]
    public class ParsedProduct
    {
        public int Id { get; set; }                    
        public string Title { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public byte[] ImageBytes { get; set; }
    }
}

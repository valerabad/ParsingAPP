using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ParsingStore_App.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ParsingStore_App.DAL
{
    public class ProductContext : DbContext
    {

        public ProductContext() : base("ProductContext")
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Site> Site { get; set; }
        public DbSet<ParsedProduct> ParsedProduct { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
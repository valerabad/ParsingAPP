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

        public DbSet<Product> Products { get; set; }
        public DbSet<Site> Sites { get; set; }                

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
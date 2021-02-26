using MyShopperStock.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopperStock.SQL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection") { }

        public DbSet<Customer> customer { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<ProductCategory> productCategory { get; set; }

    }
}

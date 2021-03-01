using MyShopperStock.Core;
using MyShopperStock.Core.Models;
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
        public DbSet<Customer> CustomerDB { get; set; }
        public DbSet<Product> ProductDB { get; set; }
        public DbSet<ProductCategory> ProductCategoryDB { get; set; }
        public DbSet<Basket> BasketDB { get; set; }
        public DbSet<BasketItem> BasketItemDB { get; set; }
        public DbSet<Order> OrderDB { get; set; }
        public DbSet<OrderItem> OrderItemDB { get; set; }


    }
}

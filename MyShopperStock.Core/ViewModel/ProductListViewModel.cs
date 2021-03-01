using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopperStock.Core.ViewModel
{
   public class ProductListViewModel
    {
        public IQueryable<Product> Product { get; set; }
        public IQueryable<ProductCategory> ProductCategories { get; set; }

    }
}

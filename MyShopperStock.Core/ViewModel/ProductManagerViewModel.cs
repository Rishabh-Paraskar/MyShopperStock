using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopperStock.Core.ViewModel
{
   public class ProductManagerViewModel
    {
        public Product Product { get; set; }
        public ICollection<ProductCategory> ProductCategoty { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopperStock.Core
{
   public class Product : BaseEntity
    {
        public string productName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int totalQuantity { get; set; }
        public int unit { get; set; }
        public decimal price { get; set; }


    }
}

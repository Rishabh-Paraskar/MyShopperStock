using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopperStock.Core.Models
{
   public class Basketitem : BaseEntity
    {
        public string BasketId { get; set; }
        public string ProductId { get; set; }
        public string Quantity { get; set; }

    }
}

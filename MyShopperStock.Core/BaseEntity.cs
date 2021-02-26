using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopperStock.Core
{
   public abstract class BaseEntity
    {
        public string id { get; set; }

        public DateTimeOffset createdAt { get; set; }

        public BaseEntity()
        {
            id = Guid.NewGuid().ToString();
            createdAt = DateTime.Now;
        }

    }
}

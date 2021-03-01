﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopperStock.Core.Models
{
   public class Basket : BaseEntity
    {
        public virtual ICollection<Basketitem> BasketItems { get; set;  }

        public Basket() {
              this.BasketItems = new List<Basketitem>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopperStock.Core
{
   public class Customer : BaseEntity
    {
        public string userId { get; set; }
        public string firstname { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string securityQuestion { get; set; }
        public string answer { get; set; }
        public string address { get; set; }
        public bool disable { get; set; }
      

        public Customer() {
            this.disable = false;
        }

    }
}

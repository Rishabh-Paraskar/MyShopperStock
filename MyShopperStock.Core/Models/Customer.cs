using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopperStock.Core
{
   public class Customer : BaseEntity
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string SecurityQuestion { get; set; }
        public string Answer { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public bool Disable { get; set; }
      

        public Customer() {
            this.Disable = false;
        }

    }
}

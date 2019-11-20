using System;
using System.Collections.Generic;
using System.Text;

namespace UmbrellaShop.Core.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public IEnumerable<Umbrella> Umbrellas { get; set; }
        public List<Order> Orders { get; set; }//one cust has many orders
    }
}

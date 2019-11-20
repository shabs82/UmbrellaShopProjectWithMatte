using System;
using System.Collections.Generic;
using System.Text;

namespace UmbrellaShop.Core.Entity
{
    public class Order
    {
        public int id { get; set; }

        public Customer Customers{ get; set; }//one order has one cust
        public List<Umbrella> Umbrellas{ get; set; }//one order has many umbrellas
        public DateTime OrderDate { get; set; }
    }
}

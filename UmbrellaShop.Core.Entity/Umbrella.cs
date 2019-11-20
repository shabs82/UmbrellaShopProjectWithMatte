using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UmbrellaShop.Core.Entity
{
    public class Umbrella
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public int Size { get; set; }
        public double Price { get; set; }
        public Order Order{ get; set; }//one umbrella has one order


    }
}

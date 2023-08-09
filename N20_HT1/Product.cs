using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N20_HT1
{
    internal class Product
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public Product(string name, float price)
        { 
            Name = name;
            Price = price;
        }
        public override string ToString()
        {
            return $"Name: {Name} - Price: {Price}";
        }
    }
}

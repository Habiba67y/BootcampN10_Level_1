using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N33_T2
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Product(string n, string d)
        {
            Id =Guid.NewGuid();
            Name = n;
            Description = d;
        }
        public override string ToString() 
        {
            return $"Name: {Name}\nDescription: {Description}";
        }
    }
}

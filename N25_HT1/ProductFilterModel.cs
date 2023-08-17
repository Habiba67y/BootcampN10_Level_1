using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N25_HT1
{
    public class ProductFilterModel
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public ProductFilterModel(string? name, string? type)
        {
            Name = name;
            Type = type;
        }
    }
}

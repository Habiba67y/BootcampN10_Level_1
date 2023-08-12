using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N23_HT1
{
    public class Product
    {
        public string Name { get; set; }
        public byte Stars { get; set; }
        public int Inventory { get; set; }
        public Product(string name, byte stars, int inventory)
        {
            Name = name;
            Stars = stars;
            Inventory = inventory;
        }
        public override string ToString()
        {
            return $"Name: {Name} | Stars: {Stars} | Inventory: {Inventory}";
        }
    }
}

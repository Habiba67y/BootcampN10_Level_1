using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N25_HT1
{
    public class Monitor: IProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsOrdered { get; set; }
        public float Price { get; set; }
        public int DisplaySize { get; set; }
        public int Refreshrate { get; set; }
        public override string ToString()
        {
            return $"\nId: {Id}\nName: {Name}\nDescription: {Description}\n" +
                $"IsOrdered: {IsOrdered}\nPrice: {Price}\nDisplaySize: {DisplaySize}\n" +
                $"Refrshrate: {Refreshrate}";
        }
        public Monitor(string name, string description, bool isOrdered, float price, int displaySize, int refreshrate)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            IsOrdered = isOrdered;
            Price = price;
            DisplaySize = displaySize;
            Refreshrate = refreshrate;
        }
        public Monitor(Monitor obj)
        {
            Id = obj.Id;
            Name = obj.Name;
            Description = obj.Description;
            Price = obj.Price;
            DisplaySize = obj.DisplaySize;
            Refreshrate = obj.Refreshrate;
        }
    }
}

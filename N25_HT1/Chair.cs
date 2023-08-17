using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N25_HT1
{
    public class Chair : IProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsOrdered { get; set; }
        public float Price { get; set; }
        public float MaxWeight { get; set; }
        public string Material { get; set; }
        public override string ToString()
        {
            return $"\nId: {Id}\nName: {Name}\nDescription: {Description}\n" +
                $"IsOrdered: {IsOrdered}\nPrice: {Price}\nMaxWeight: {MaxWeight}\n" +
                $"Material: {Material}";
        }
        public Chair(string name, string description, bool isOrdered, float price, float maxweight, string material)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            IsOrdered = isOrdered;
            Price = price;
            MaxWeight = maxweight;
            Material = material;
        }
        public Chair(Chair obj)
        {
            Id = obj.Id;
            Name = obj.Name;
            Description = obj.Description;
            Price = obj.Price;
            MaxWeight = obj.MaxWeight;
            Material = obj.Material;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N25_HT1
{
    public class Laptop : IProduct
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsOrdered { get; set; }
        public float Price { get; set; }
        public string CpuBrand { get; set; }
        public string CpuModel { get; set; }
        public override string ToString()
        {
            return $"\nId: {Id}\nName: {Name}\nDescription: {Description}\n" +
                $"IsOrdered: {IsOrdered}\nPrice: {Price}\nCpu brand: {CpuBrand}\n" +
                $"Cpu model: {CpuModel}";
        }
        public Laptop(string name, string description, bool isOrdered, float price, string cpuBrand, string cpuModel)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            IsOrdered = isOrdered;
            Price = price;
            CpuBrand = cpuBrand;
            CpuModel = cpuModel;
        }
        public Laptop(Laptop obj)
        {
            Id = obj.Id;
            Name = obj.Name;
            Description = obj.Description;
            Price = obj.Price;
            CpuBrand = obj.CpuBrand;
            CpuModel = obj.CpuModel;
        }
    }
}

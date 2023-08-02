using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N17_HT1
{
    internal sealed class Bmw: CarRental
    {
        public string ModelName { get; set; }
        public float RentPricePerHour = 30;
        public Bmw(string modelName)
        {
            BrandName = "Bmw modelini qanaqadir nomi";
            ModelName = modelName;
        }
    }
}

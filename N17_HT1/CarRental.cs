using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N17_HT1
{
    internal abstract class CarRental
    {
        public bool isRented { get; set; }
        public DateTime RentStartTime { get; set; }
        public float Balance { get; set; }
        public string BrandName { get; set; }
        public Guid Id = Guid.NewGuid();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N38_HT2
{
    public class Order
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime OrderDate { get; set; }
        public int Amount { get; set; }
    }
}

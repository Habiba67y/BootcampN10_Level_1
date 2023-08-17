using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N25_HT1
{
    public interface IProduct
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        bool IsOrdered { get; set; }
        float Price { get; set; }
    }
}

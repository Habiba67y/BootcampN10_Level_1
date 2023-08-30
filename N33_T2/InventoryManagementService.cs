using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N33_T2
{
    public abstract class InventoryManagementService
    {
        public List<Product> Products { get; init; }
        public InventoryManagementService()
        {
            Products = new List<Product>();
        }
        public InventoryManagementService(List<Product> products)
        {
            Products = products;
        }
    }
}

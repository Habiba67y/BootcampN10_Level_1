using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N33_T2
{
    public sealed class OnlineStoreInventoryManagement : InventoryManagementService
    {
        public OnlineStoreInventoryManagement() : base(new List<Product> { new Product("name1", "description1"), new Product("name2", "description2") })
        {
        }
        public void Display()
        {
            Products.ForEach(Console.WriteLine);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N32_T3
{
    public class ProductService
    {
        public List<Product> products = new List<Product>();
        private static ProductService _instance;
        private ProductService()
        {
            
        }
        public static ProductService GetInstance()
        {
            if(_instance is null)
                _instance = new ProductService();
            return _instance;
        }
        public void Add(string name, string description)
        {
            try
            {
                var product = new Product(name, description);
                products.Add(product);
            }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
}
        public void Clone(Guid id)
        {
            var p = products.FirstOrDefault(p => p.Id == id);
            if (p != null)
            {
                var product = new Product(p);
                products.Add(product);                
            }
        }
        public void Display()
        {
            products.ForEach(Console.WriteLine);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N25_HT1
{
    public class ProductServcie
    {
        public List<IProduct> Inventory = new List<IProduct>();
        public Guid Add(IProduct product)
        {
            Inventory.Add(product);
            return product.Id;
        }
        public List<string> GetFilterData()
        {
            Console.WriteLine(Inventory.Count());
            if (Inventory.Count() == 0)
            {
                return new List<string>();
            }
            new ProductFilterDataModel().ProductTypes = Inventory.Select(product => product.GetType().FullName).Distinct();
            return Inventory.Select(product => product.GetType().FullName).Distinct().ToList();
        }
        public List<IProduct> Get(ProductFilterModel filterModel)
        {
            var products = Inventory.Where(product =>
            (filterModel.Name is null || product.Name == filterModel.Name)
            && (filterModel.Type is null || product.GetType().FullName == filterModel.Type)).ToList();
            return new List<IProduct>(products);
        }
        public IProduct Order(Guid productId)
        {
            var product = Inventory.FirstOrDefault(product => product.Id == productId);
            if (product != null)
            {
                product.IsOrdered = true;
                return IProductCopy(product);
            }
            throw new Exception("Bunday mahsulot yo'q");
        }
        public IProduct Return(Guid productId)
        {
            var product = Inventory.FirstOrDefault(product => product.Id == productId);
            if (product != null)
            {
                product.IsOrdered = false;
                return IProductCopy(product);
            }
            throw new Exception("Bunday mahsulot yo'q");
        }
        public IProduct IProductCopy(IProduct obj)
        {
            if (obj is Laptop laptop)
            {
                return new Laptop(laptop);
            }
            else if (obj is Monitor monitor)
            {
                return new Monitor(monitor);
            }
            else if(obj is Chair chair)
            {
                return new Chair(chair);
            }
            else { throw new Exception("Xato produkt tipi"); }
        }
    }
}

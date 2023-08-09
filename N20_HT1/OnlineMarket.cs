using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N20_HT1
{
    internal class OnlineMarket
    {
        public List<Product> Products = new List<Product>();
        private readonly IPaymentProvider _provider;
        public IDebitCard destinationCard;
        public OnlineMarket(IPaymentProvider provider) 
        {
            _provider = provider;
        }
        public void Add(Product product)
        {
            Products.Add(product);
        }
        public void Buy(string name, int number, IDebitCard card)
        {
            var price = default(float);
            foreach (var product in Products)
            {
                if (product.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    price = product.Price;
                    break;
                }
            }
            var amount = price * number;
            _provider.Transfer(card, destinationCard, amount);
        }
        public void ShowProducts()
        {
            foreach (var product in Products)
            {
                Console.WriteLine(product.ToString());
            }
        }
    }
}

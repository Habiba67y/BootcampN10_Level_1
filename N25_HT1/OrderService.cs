using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N25_HT1
{
    public class OrderService
    {
        private readonly ProductServcie _productService;
        private readonly PaymentService _paymentService;
        public OrderService(ProductServcie productService, PaymentService paymentService)
        {
            _productService = productService;
            _paymentService = paymentService;
        }
        public bool Order(Guid id, DebitCard card)
        {

            if (_paymentService.CheckOut(_productService.Order(id).Price, card))
            {
                return true;
            }
            return false;
        }
        public bool Order(ProductFilterModel filterModel, DebitCard card)
        {
            var amount = _productService.Get(filterModel).Select(product => product.Price).Sum();
            if (_paymentService.CheckOut(amount, card))
            {
                return true;
            }
            return false;
        }
    }
}

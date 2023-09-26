using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N45_HT1.Models
{
    public class OrderProduct
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public int Count { get; set; }
        public OrderProduct(Guid productId, Guid orderId, int count)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            OrderId = orderId;
            Count = count;
        }
    }
}

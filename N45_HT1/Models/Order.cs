using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N45_HT1.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public int Amount { get; set; }
        public Guid UserId { get; set; }
        public Order(int amount, Guid userId)
        {
            Id = Guid.NewGuid();
            Amount = amount;
            UserId = userId;
        }
    }
}

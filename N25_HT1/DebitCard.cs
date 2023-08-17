using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N25_HT1
{
    public class DebitCard
    {
        public string CardNumber { get; set; }
        public float Balance { get; set; }
        public DebitCard(string cardNumber, float balance)
        {
            CardNumber = cardNumber;
            Balance = balance;
        }
    }
}

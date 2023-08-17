using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N25_HT1
{
    public class PaymentService
    {
        public bool CheckOut(float amount, DebitCard debitCard)
        {
            if (debitCard.Balance < amount)
            {
                return false;
            }
            debitCard.Balance -= amount;
            return true;
        }
    }
}

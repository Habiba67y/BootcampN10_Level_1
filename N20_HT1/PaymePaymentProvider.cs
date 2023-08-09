using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N20_HT1
{
    internal class PaymePaymentProvider: IPaymentProvider
    {
        public int TransferInterest { get; init; }
        public void Transfer(IDebitCard sourceCard, IDebitCard destinationCard, float amount)
        {
            sourceCard.Balance -= (amount + amount / 100 * TransferInterest);
            destinationCard.Balance += amount;

        }
        public PaymePaymentProvider(int transferInterest)
        {
            TransferInterest = transferInterest;
        }
    }
}

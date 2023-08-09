using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N20_HT1
{
    internal interface IPaymentProvider
    {
        void Transfer(IDebitCard sourceCard, IDebitCard destinationCard, float amount);
        int TransferInterest { get; init; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N20_HT1
{
    internal interface IDebitCard
    {
        string CardNumber { get; set; }
        string BankName { get; init; }
        float Balance { get; set; }
    }
}

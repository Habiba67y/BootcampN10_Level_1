using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N20_HT1
{
    internal class KapitalUzcard: IDebitCard
    {
        public string CardNumber { get; set; }
        public string BankName { get; init; }
        public float Balance { get; set; }
        public KapitalUzcard(string bankName) 
        {
            BankName = bankName;
        }
    }
}

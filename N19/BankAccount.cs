using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N19
{
    internal abstract class BankAccount
    {
        protected string accountHoldName;
        protected int accountNumber;
        protected int balance;
        public virtual void Deposit()
        { }
        public virtual void WithDraw() 
        { }
    }
}

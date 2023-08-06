using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N19
{
    internal class Bank: BankAccount
    {
        private List<BankAccount> accounts = new List<BankAccount>();
        private int numberOfAccount;
        public void AddAccount(BankAccount ba)
        {
            accounts.Add(ba);
        }
    }
}

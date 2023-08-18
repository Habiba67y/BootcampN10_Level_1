using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N26_HT1
{
    public class Money
    {
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
        public MoneyType Type { get; set; }
        public override string ToString()
        {
            return $"{Amount} {Currency} {Type}";
        }
        public static Money operator +(Money money1, Money money2)
        {
            // hamma pullarni uzs ga o'tkazish:
            if (money1.Currency == Currency.USD)
            {
                money1.Amount *= 12_089m;
            }
            if (money2.Currency == Currency.USD)
            {
                money2.Amount *= 12_089m;
            }
            if (money1.Currency == Currency.RUB)
            {
                money1.Amount *= 124.90m;
            }
            if (money2.Currency == Currency.RUB)
            {
                money2.Amount *= 124.90m;
            }

            //qo'shish:
            if (money1.Type == money2.Type)
            {
                money1.Amount += money2.Amount;
                return money1;
            }
            else if (money1.Type == MoneyType.InBalance)
            {
                money1.Amount -= money2.Amount;
                return money1;
            }
            else
            {
                money2.Amount -= money1.Amount;
                return money2;
            }
        }
        
    }
}

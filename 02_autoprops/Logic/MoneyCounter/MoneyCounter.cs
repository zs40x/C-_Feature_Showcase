using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_autoprops.Logic.Data;

namespace _02_autoprops.Logic.MoneyCounter
{
    internal class MoneyCounter
    {
        private readonly object _countLock = new object();

        public Currency Currency { get; }
        public Money Total { get; private set; }

        public MoneyCounter(Currency currency)
        {
            Currency = currency;
            Total = new Money(Currency, 0);
        }

        public void Count(string money)
        {
            lock (_countLock)
            {
                Total += Money.Parse(money);
            }
        }
    }
}

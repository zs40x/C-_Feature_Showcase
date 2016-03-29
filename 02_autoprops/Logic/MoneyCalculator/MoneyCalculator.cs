using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02_autoprops.Logic.Data;

namespace _02_autoprops.Logic.MoneyCalculator
{
    internal class MoneyCalculator
    {
        private readonly object _totalLock = new object();
       
        public Currency Currency { get; }

        public Money Total { get; private set; }
        
        public event EventHandler<TotalChangedEventArgs> TotalChanged;

        public MoneyCalculator(Currency currency)
        {
            Currency = currency;
            Total = new Money(Currency, 0);
        }

        public void Calculate(string moneyString, string calcOperator)
        {
            var money = Money.Parse(moneyString);

            CalculationAction(calcOperator)(money);

            TotalChanged?.Invoke(this, new TotalChangedEventArgs(Total));
        }

        private Action<Money> CalculationAction(string calcOperator)
        {
            switch (calcOperator)
            {
                case "+":
                    return (m) => Total += m;    
                case "-":
                    return (m) => Total -= m;
                case "*":
                    return (m) => Total *= m;
                case "/":
                    return (m) => Total /= m;
            }

            throw new InvalidOperationException("no valid calculation operator used");
        }
    }
}

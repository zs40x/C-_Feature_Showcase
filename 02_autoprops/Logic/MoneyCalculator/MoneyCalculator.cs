using System;
using System.Collections.Generic;
using _02_autoprops.Logic.Data;

namespace _02_autoprops.Logic.MoneyCalculator
{
    public class MoneyCalculator
    {
        private readonly Dictionary<string, Func<Money, Money, Money>> _operatorCalcFuncs =
            new Dictionary<string, Func<Money, Money, Money>>()
            {
                {"+", (t, m) => t + m},
                {"-", (t, m) => t - m},
                {"*", (t, m) => t * m},
                {"/", (t, m) => t / m}
            };

       
        public Currency Currency { get; }

        public Money Total { get; private set; }
        
        public event EventHandler<TotalChangedEventArgs> TotalChanged;

        public MoneyCalculator(Currency currency, decimal initialTotal = 0)
        {
            Currency = currency;
            Total = new Money(Currency, initialTotal);
        }


        public void Calculate(string moneyString, string withOperator)
        {
            if (IsAKnownOperator(withOperator))
                throw new InvalidOperationException("no valid calculation operator used");
            
            Total = DoCalculate(withOperator)(Total, Money.Parse(moneyString));

            TotalChanged?.Invoke(this, new TotalChangedEventArgs(Total));
        }

        private bool IsAKnownOperator(string calcOperator)
            => !_operatorCalcFuncs.ContainsKey(calcOperator);

        private Func<Money, Money, Money> DoCalculate(string calculationOperator)
            => _operatorCalcFuncs[calculationOperator];

    }
}

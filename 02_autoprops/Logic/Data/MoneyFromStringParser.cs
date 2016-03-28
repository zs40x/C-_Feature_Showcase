using System;
using System.Text.RegularExpressions;

namespace _02_autoprops.Logic.Data
{
    internal class MoneyFromStringParser
    {
        private readonly string _moneyString;
        private Currency _currency;
        private decimal _amount;

        public MoneyFromStringParser(string moneyString)
        {
            _moneyString = moneyString;
        }

        public Money ToMoney()
        {
            if (!IsAValidMoneyString())
                throw new ArgumentException(_moneyString + " is not a Money String");

            if (!AmountParsedToDecimal())
                throw new ArgumentException(SplittedAmount() + " is not a valid decimal");

            if (!CurrencyParsedToEnum)
                throw new ArgumentException(SplittedCurrency() + " is not a valid Currency");

            return new Money(_currency, _amount);
        }

        private bool IsAValidMoneyString()
            => Regex.IsMatch(_moneyString, @"^\d+(,)?(\d*)?\s(\w+)$");

        private string SplittedAmount()
            => _moneyString.Split(' ')[0];

        private string SplittedCurrency()
            => _moneyString.Split(' ')[1];

        private bool AmountParsedToDecimal()
            => decimal.TryParse(SplittedAmount(), out _amount);

        private bool CurrencyParsedToEnum
            => Enum.TryParse(SplittedCurrency(), out _currency);
    }
}

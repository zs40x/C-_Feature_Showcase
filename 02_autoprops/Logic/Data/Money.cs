using System;
using System.Text.RegularExpressions;

namespace _02_autoprops.Logic.Data
{
    public sealed class Money : IEquatable<Money>
    {
        public static Money NullEuro = new Money(Currency.EUR, (decimal)0.00);

        public Currency Currency { get; }
        public decimal Amount { get; }

        public Money(Currency currency, decimal amount)
        {
            Currency = currency;
            Amount = amount;
        }

        public static Money operator +(Money lhs, Money rhs)
        {
            if(lhs.Currency != rhs.Currency)
                throw new InvalidOperationException("Adition only for equal currencies allowed");

            return new Money(lhs.Currency, Round(lhs.Amount + rhs.Amount));
        }

        private static decimal Round(decimal amount)
            => decimal.Round(amount, 2, MidpointRounding.AwayFromZero);

        public override string ToString()
            => $"{Amount} {Currency}";

        public static Money Parse(string money)
            => new MoneyFromStringParser(money).ToMoney();
        
        public override bool Equals(object other)
        {
            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(other, this))
                return true;

            if (GetType() != other.GetType())
                return false;

            return Equals(other as Money);
        }

        public bool Equals(Money other)
        {
            return (other.Currency == Currency && other.Amount == Amount);
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Currency + Amount).GetHashCode();
        }
    }
}

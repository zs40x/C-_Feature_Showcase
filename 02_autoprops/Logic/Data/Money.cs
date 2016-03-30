using System;

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


        #region Operators
        public static Money operator +(Money lhs, Money rhs)
        {
            RaiseExceptionIfCurrencyIsNotEqual(lhs, rhs);

            return new Money(lhs.Currency, Round(lhs.Amount + rhs.Amount));
        }

        public static Money operator -(Money lhs, Money rhs)
        {
            RaiseExceptionIfCurrencyIsNotEqual(lhs, rhs);

            return new Money(lhs.Currency, Round(lhs.Amount - rhs.Amount));
        }

        public static Money operator *(Money multiplier, Money multiplicant)
        {
            RaiseExceptionIfCurrencyIsNotEqual(multiplier, multiplicant);

            return new Money(multiplier.Currency, Round(multiplier.Amount * multiplicant.Amount));
        }

        public static Money operator /(Money divident, Money divisor)
        {
            RaiseExceptionIfCurrencyIsNotEqual(divident, divisor);

            return new Money(divident.Currency, Round(divident.Amount / divisor.Amount));
        }

        private static void RaiseExceptionIfCurrencyIsNotEqual(Money a, Money b)
        {
            if (a.Currency == b.Currency)
                return;

            throw new InvalidOperationException($"Currencies a not equal - {a.Currency}<>{b.Currency}");
        }
        #endregion

        private static decimal Round(decimal amount)
            => decimal.Round(amount, 2, MidpointRounding.AwayFromZero);
        
        public static Money Parse(string money)
            => new MoneyFromStringParser(money).ToMoney();

        public override string ToString()
            => $"{Amount.ToString("0.00")} {Currency}";

        #region Equals / Hashing
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
            return other.GetHashCode() == GetHashCode();
        }

        public override int GetHashCode()
        {
            return (GetType().ToString() + Currency.GetHashCode() + Amount.GetHashCode()).GetHashCode();
        }
        #endregion
    }
}

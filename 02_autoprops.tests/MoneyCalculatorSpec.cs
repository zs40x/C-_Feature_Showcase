using FluentAssertions;
using Xunit;
using _02_autoprops.Logic.Data;
using _02_autoprops.Logic.MoneyCalculator;

namespace _02_autoprops.tests
{
    public class MoneyCalculatorSpec
    {
        private readonly MoneyCalculator _fcut =  new MoneyCalculator(Currency.EUR, 4m);

        [Fact]
        private void Adds_1EUR_is_4EUR()
        {
            _fcut.Calculate("1 EUR", "+");

            _fcut.Total.Should().Be(new Money(Currency.EUR, 5m));
        }

        [Fact]
        private void Subtract_2EUR_is_2EUR()
        {
            _fcut.Calculate("2 EUR", "-");

            _fcut.Total.Should().Be(new Money(Currency.EUR, 2m));
        }

        [Fact]
        private void Mulitiply_by_2EUR_is_8EUR()
        {
            _fcut.Calculate("2 EUR", "*");

            _fcut.Total.Should().Be(new Money(Currency.EUR, 8m));
        }

        [Fact]
        private void Divide_by_2EUR_is_2EUR()
        {
            _fcut.Calculate("2 EUR", "/");

            _fcut.Total.Should().Be(new Money(Currency.EUR, 2m));
        }  
    }
}

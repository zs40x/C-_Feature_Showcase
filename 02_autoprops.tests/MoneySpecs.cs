using System;
using FluentAssertions;
using Xunit;
using _02_autoprops.Logic.Data;

namespace _02_autoprops.tests
{
    public class MoneySpecs
    {
        private static readonly Money OneEuro = new Money(Currency.EUR, 1m);
        private static readonly Money TwoEuro = new Money(Currency.EUR, 2m);
        private static readonly Money FourEuro = new Money(Currency.EUR, 4m);

        [Fact]
        public void Null_is_not_NULL() 
            => Money.NullEuro.Should().NotBeNull();

        [Fact]
        public void Is_initialized()
        {
            OneEuro.Currency.Should().Be(Currency.EUR);
            OneEuro.Amount.Should().Be(1);
        }

        [Fact]
        public void Add_1_EUR_to_1_EUR_equals_2()
        {
            var addResult = OneEuro + OneEuro;

            addResult.Should().Be(TwoEuro);
        }

        [Fact]
        public void Subtract_1_EUR_from_2_equals_1()
        {
            var subtractionResult = TwoEuro - OneEuro;

            subtractionResult.Should().Be(OneEuro);
        }

        [Fact]
        public void Multiply_2_EUR_by_two_equals_4()
        {
            var product = TwoEuro*TwoEuro;

            product.Should().Be(FourEuro);
        }

        [Fact]
        public void Divide_four_EUR_by_two_equals_2()
        {
            var qoutient = FourEuro/TwoEuro;

            qoutient.Should().Be(TwoEuro);
        }

        public void Add_Rounds_Exact()
        {
            var addResult = 
                new Money(Currency.EUR, 12.31m) + new Money(Currency.EUR, 14.46m);

            addResult.Should().Be(new Money(Currency.EUR, 181.69m));
        }

        [Fact]
        public void Parses_1comma00_EUR()
        {
            var result = Money.Parse("1,00 EUR");

            result.Should().NotBeNull();
            result.Amount.Should().Be((decimal) 1.00);
            result.Currency.Should().Be(Currency.EUR);
        }

        [Fact]
        public void Parse_invalid_currency_raises_exception()
        {
            Action action = () => Money.Parse("1 ZZZ");

            action.ShouldThrow<ArgumentException>();
        }

        [Theory]
        [InlineData("1")]
        [InlineData("1 ")]
        [InlineData("1.0 EUR")]
        [InlineData("EUR")]
        public void Parse_invalid_string_raises_exception(string money)
        {
            Action action = () => Money.Parse(money);

            action.ShouldThrow<ArgumentException>();
        }
    }
}

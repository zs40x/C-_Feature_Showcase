using _02_autoprops.Logic.Data;

namespace _02_autoprops.Logic.MoneyCalculator
{
    class TotalChangedEventArgs
    {
        public Money Total { get; private set; }

        public TotalChangedEventArgs(Money total)
        {
            Total = total;
        }
    }
}

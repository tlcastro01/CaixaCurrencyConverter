namespace CurrencyConverter
{
    public interface ICurrencyConverter
    {
        Money Convert(Money from, Currency to);
    }
}
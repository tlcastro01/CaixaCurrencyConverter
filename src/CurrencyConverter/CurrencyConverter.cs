using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter;

public class Currency_Converter : ICurrencyConverter
{
    private readonly IRateProvider rateProvider;

    public Currency_Converter(IRateProvider rateProvider)
        => this.rateProvider = rateProvider;

    public Money Convert(Money from, Currency to)
    {
        // USD to USD
        if (from.Currency == to)
            return from;

        try
        {
            var rate = rateProvider.GetRate(from.Currency, to);
            var convertedAmount = from.Amount * rate;

            return new Money(convertedAmount, to);
        }
        catch (Exception ex)
        {
            throw ;
        }
    }
}


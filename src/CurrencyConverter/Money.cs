using System;

namespace CurrencyConverter;

public readonly struct Money
{
    public decimal Amount { get; }
    public Currency Currency { get; }

    public Money(decimal amount, Currency currency)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount));

        this.Amount = amount;
        this.Currency = currency;
    }

    // recomendação do copilot
    // public override bool Equals(object obj) 
    // {
    //     if (obj is Money other)
    //     {
    //         return this.Amount == other.Amount && this.Currency == other.Currency;
    //     }
    //     return false;
    // }

    // public override int GetHashCode()
    // {
    //     return HashCode.Combine(Amount, Currency);
    // }

    public static bool operator ==(Money left, Money right)
    {
        if (left.Amount == right.Amount && left.Currency == right.Currency)
            return true;
        return false;
    }

    public static bool operator !=(Money left, Money right)
    {
        if (left.Amount == right.Amount && left.Currency == right.Currency)
            return false;
        return true;
    }
}



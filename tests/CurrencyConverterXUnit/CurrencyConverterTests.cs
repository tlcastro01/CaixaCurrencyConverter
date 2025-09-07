using System;
using System.Collections.Generic;
using CurrencyConverter;
using Xunit;

namespace CurrencyConverterXUnitTest;

// TAREFA
// Testar Conversão A -> B
// Testar Conversão A -> B, B -> A (colocar na tabela A->B e B->A)

public class FakeRateProvider : IRateProvider
{
    public decimal GetRate(Currency from, Currency to)
    {
        if (from == Currency.USD && to == Currency.BRL) return 5.00M;
        if (from == Currency.BRL && to == Currency.USD) return 0.20M;
        throw new InvalidOperationException("Rate not found");
    }
}

public class CurrencyConverterTests
{

    [Fact]
    public void GivenAMoneytype_WhenConverted_ThenReturnTheRightObject() //Está dependendo do RateProvider
    {
        // Arrange
        var rateProvider = new RateProvider();
        var converter = new Currency_Converter(rateProvider);
        var from1 = new Money(10.00M, Currency.USD);
        var to1 = Currency.BRL;

        //var from2 = new Money(10.00M, Currency.BRL); Faz sentido? O valor da taxa de conversão, teoricamente, é variável.
        //var to2 = Currency.USD;            

        // Act
        var result = converter.Convert(from1, to1);
        //var result2 = converter.Convert(from2, to2);

        // Assert
        //Assert.That(result, Is.InstanceOf<Money>());
        //Assert.That(result.Currency, Is.EqualTo(Currency.BRL));
        Assert.IsType<Money>(result);
        Assert.Equal(Currency.BRL, result.Currency);
    }


    [Fact]
    public void GivenUSD_WhenConvertedToBRL_ThenReturnTheRightValue()
    {
        // Arrange
        var rateProvider = new FakeRateProvider();
        var converter = new Currency_Converter(rateProvider);
        var from = new Money(10.00M, Currency.USD);
        var to = Currency.BRL;

        // Act
        var result = converter.Convert(from, to);

        // Assert
        //Assert.Equal(50.00M, result.Amount);
        //Assert.Equal(Currency.BRL, result.Currency);
        Assert.Equal(new Money(50.00M, Currency.BRL), result);

    }
}


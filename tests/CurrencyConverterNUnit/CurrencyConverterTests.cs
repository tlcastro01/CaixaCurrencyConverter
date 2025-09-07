using CurrencyConverter;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace CurrencyConverterNUnitTest;

    // TAREFA
    // Testar Conversão A -> B
    // Testar Conversão A -> B, B -> A (colocar na tabela A->B e B->A)

public class CurrencyConverterTests
{

    [Test]
    public void GivenAMoneytype_WhenConverted_ThenReturnTheRightObject() //Está dependendo do RateProvider
    {
        // Arrange
        var rateProvider = new RateProvider();
        var converter = new Currency_Converter(rateProvider);
        var from1 = new Money(10.00M, Currency.USD);
        var to1 = Currency.BRL;

        //var from2 = new Money(10.00M, Currency.BRL); Não faz sentido pq o valor da taxa de conversão, teoricamente, é variável.
        //var to2 = Currency.USD;            

        // Act
        var result = converter.Convert(from1, to1);
        //var result2 = converter.Convert(from2, to2);

        // Assert
        Assert.That(result, Is.InstanceOf<Money>());
        Assert.That(result.Currency, Is.EqualTo(Currency.BRL));
    }
}


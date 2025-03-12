using Marketplace.Framework;

namespace Marketplace.Domain;

public class Money : Value<Money>
{
    private const string DefaultCurrency = "EUR";
    
    public decimal Amount { get; }
    public string CurrencyCode { get; }

    public static Money FromDecimal(decimal amount) =>
        new Money(amount);
        
    public static Money FromString(string amount) =>
        new Money(decimal.Parse(amount));
    
    protected Money(decimal amount, string currencyCode = DefaultCurrency)
    {
        if (decimal.Round(amount, 2) != amount)
        {
            throw new ArgumentOutOfRangeException(
                nameof(amount),
                "Amount cannot have more than two decimals");
        }

        Amount = amount;
        CurrencyCode = currencyCode;
    }

    public Money Add(Money summand) => new(Amount + summand.Amount);
        
    public Money Subtract(Money subtrahend) => new(Amount - subtrahend.Amount);
        
    public static Money operator +(Money summand1, Money summand2) => summand1.Add(summand2);

    public static Money operator -(Money minuend, Money subtrahend) => minuend.Subtract(subtrahend);
}
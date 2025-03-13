using Marketplace.Domain.Service;

namespace Marketplace.Domain;

public class Price : Money
{
    public new static Price FromDecimal(decimal amount, string currency, ICurrencyLookup currencyLookup) =>
        new(amount, currency, currencyLookup);

    public new static Price FromString(string amount, string currency, ICurrencyLookup currencyLookup) =>
        new(decimal.Parse(amount), currency, currencyLookup);

    
    public Price(decimal amount, string currencyCode, ICurrencyLookup currencyLookup) 
        : base(amount, currencyCode, currencyLookup)
    {
        if (amount < 0)
            throw new ArgumentException(
                "Price cannot be negative",
                nameof(amount));
    }
}
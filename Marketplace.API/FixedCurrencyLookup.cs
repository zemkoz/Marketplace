using Marketplace.Domain;
using Marketplace.Domain.Service;

namespace Marketplace.API;

public class FixedCurrencyLookup : ICurrencyLookup
{
    private static readonly IEnumerable<Currency> _currencies =
    [
        new()
        {
            CurrencyCode = "EUR",
            DecimalPlaces = 2,
            InUse = true
        },
        new()
        {
            CurrencyCode = "USD",
            DecimalPlaces = 2,
            InUse = true
        }
    ];

    public Currency FindCurrency(string currencyCode)
    {
        var currency = _currencies.FirstOrDefault(x => x.CurrencyCode == currencyCode);
        return currency ?? Currency.None;
    }
}
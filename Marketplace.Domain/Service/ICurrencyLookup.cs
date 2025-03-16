namespace Marketplace.Domain.Service;

public interface ICurrencyLookup
{
    Currency FindCurrency(string currencyCode);
}
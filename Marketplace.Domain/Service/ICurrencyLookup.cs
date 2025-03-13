namespace Marketplace.Domain.Service;

public interface ICurrencyLookup
{
    CurrencyDetails FindCurrency(string currencyCode);
}
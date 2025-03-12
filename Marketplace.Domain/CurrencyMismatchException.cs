namespace Marketplace.Domain;

public class CurrencyMismatchException(string message) : Exception(message);
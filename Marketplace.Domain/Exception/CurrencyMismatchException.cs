namespace Marketplace.Domain.Exception;

public class CurrencyMismatchException(string message) : System.Exception(message);
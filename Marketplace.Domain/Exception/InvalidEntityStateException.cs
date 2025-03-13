namespace Marketplace.Domain.Exception;

public class InvalidEntityStateException(
    object entity,
    string message) 
    : System.Exception($"Entity {entity.GetType().Name} state change rejected, {message}");


using Marketplace.Framework;

namespace Marketplace.Domain;

public class UserId : Value<UserId>
{
    public Guid Value { get;  }

    public UserId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(value), "User id cannot be empty");
        }
        
        Value = value;
    }
}
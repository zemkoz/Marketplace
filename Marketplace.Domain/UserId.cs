﻿using Marketplace.Framework;

namespace Marketplace.Domain;

public class UserId : Value<UserId>
{
    private readonly Guid _value;

    public UserId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(value), "User id cannot be empty");
        }
        
        _value = value;
    }
}
﻿using Marketplace.Framework;

namespace Marketplace.Domain;

public class ClassifiedAdId : Value<ClassifiedAdId>
{
    private readonly Guid _value;

    public ClassifiedAdId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(value), "Classified Ad id cannot be empty");
        }
        
        _value = value;
    }
}
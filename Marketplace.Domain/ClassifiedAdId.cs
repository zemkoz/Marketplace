﻿using Marketplace.Framework;

namespace Marketplace.Domain;

public class ClassifiedAdId : Value<ClassifiedAdId>
{
    public Guid Value { get;  }

    public ClassifiedAdId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentNullException(nameof(value), "Classified Ad id cannot be empty");
        }
        
        Value = value;
    }
    
    public static implicit operator Guid(ClassifiedAdId self) => self.Value;
}
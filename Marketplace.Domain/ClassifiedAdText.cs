using Marketplace.Framework;

namespace Marketplace.Domain;

public class ClassifiedAdText : Value<ClassifiedAdText>
{
    public static ClassifiedAdText FromString(string title) => new(title);

    public string Value { get; }

    internal ClassifiedAdText(string value)
    {
        Value = value;
    }
    
    public static implicit operator string(ClassifiedAdText text)
        => text.Value;
}

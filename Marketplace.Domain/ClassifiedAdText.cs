using Marketplace.Framework;

namespace Marketplace.Domain;

public class ClassifiedAdText : Value<ClassifiedAdText>
{
    public static ClassifiedAdText FromString(string title) => new(title);

    public string Value { get; }

    private ClassifiedAdText(string value)
    {
        Value = value;
    }
}

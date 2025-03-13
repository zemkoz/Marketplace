using Marketplace.Framework;

namespace Marketplace.Domain;

public class ClassifiedAdTitle : Value<ClassifiedAdTitle>
{
    public static ClassifiedAdTitle FromString(string title) => new(title);

    public string Value { get; }

    private ClassifiedAdTitle(string value)
    {
        if (value.Length > 100)
        {
            throw new ArgumentOutOfRangeException(
                "Title cannot be longer that 100 characters",
                nameof(value));
        }

        Value = value;
    }
}

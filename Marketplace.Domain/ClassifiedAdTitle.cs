﻿using System.Text.RegularExpressions;
using Marketplace.Framework;

namespace Marketplace.Domain;

public class ClassifiedAdTitle : Value<ClassifiedAdTitle>
{
    public static ClassifiedAdTitle FromString(string title) => new(title);

    public static ClassifiedAdTitle FromHtml(string htmlTitle)
    {
        var supportedTagsReplaced = htmlTitle
            .Replace("<i>", "*")
            .Replace("</i>", "*")
            .Replace("<b>", "**")
            .Replace("</b>", "**");

        var value = Regex.Replace(supportedTagsReplaced, "<.*?>", string.Empty);

        return new ClassifiedAdTitle(value);
    }
    
    public string Value { get; }

    internal ClassifiedAdTitle(string value)
    {
        if (value.Length > 100)
        {
            throw new ArgumentOutOfRangeException(
                "Title cannot be longer that 100 characters",
                nameof(value));
        }

        Value = value;
    }
    
    public static implicit operator string(ClassifiedAdTitle title)
        => title.Value;
}

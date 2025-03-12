namespace Marketplace.Domain;

public class ClassifiedAd
{
    public ClassifiedAdId Id { get; private set; }

    private UserId _ownerId;
    private string _title;
    private string _text;
    private decimal _price;

    public ClassifiedAd(ClassifiedAdId id, UserId ownerId)
    {
        Id = id;
        _ownerId = ownerId;
    }
    
    public void UpdateTitle(string title)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(title));
        _title = title;
    }
    
    public void UpdateText(string text)
    {
        ArgumentException.ThrowIfNullOrEmpty(nameof(text));
        _text = text;
    }

    public void UpdatePrice(decimal price)
    {
        if (price < 0)
        {
            throw new ArgumentException("Price cannot be negative");
        }
        _price = price;
    }
    
    
}
using Marketplace.Domain.Exception;
using Marketplace.Framework;

namespace Marketplace.Domain;

public class ClassifiedAd : Entity
{
    public ClassifiedAdId Id { get;  }

    public UserId OwnerId { get; }
    public ClassifiedAdTitle Title { get; private set; }
    public ClassifiedAdText Text { get; private set; }
    public Price Price { get; private set; }
    public ClassifiedAdState State { get; private set; }
    public UserId ApprovedBy { get; private set; }

    public ClassifiedAd(ClassifiedAdId id, UserId ownerId)
    {
        Id = id;
        OwnerId = ownerId;
        State = ClassifiedAdState.Inactive;
        EnsureValidState();
        Raise(new Events.ClassifiedAdCreated
        {
            Id = id.Value,
            OwnerId = ownerId.Value
        });
    }

    public void UpdateTitle(ClassifiedAdTitle title)
    {
        Title = title;
        EnsureValidState();
        
        Raise(new Events.ClassifiedAdTitleChanged
        {
            Id = Id.Value,
            Title = title.Value
        });
    }

    public void UpdateText(ClassifiedAdText text)
    {
        Text = text;
        EnsureValidState();
        Raise(new Events.ClassifiedAdTextUpdated
        {
            Id = Id.Value,
            AdText = text.Value
        });
    }

    public void UpdatePrice(Price price)
    {
        Price = price;
        EnsureValidState();
        
        Raise(new Events.ClassifiedAdPriceUpdated
        {
            Id = Id.Value,
            Price = Price.Amount,
            CurrencyCode = Price.Currency.CurrencyCode
        });
    }

    public void RequestToPublish()
    {
        State = ClassifiedAdState.PendingReview;
        EnsureValidState();
        
        Raise(new Events.ClassifiedAdSentForReview{Id = Id.Value});
    }

    protected override void EnsureValidState()
    {
        var valid =
            Id != null &&
            OwnerId != null &&
            (State switch
            {
                ClassifiedAdState.PendingReview =>
                    Title != null
                    && Text != null
                    && Price?.Amount > 0,
                ClassifiedAdState.Active =>
                    Title != null
                    && Text != null
                    && Price?.Amount > 0
                    && ApprovedBy != null,
                _ => true
            });

        if (!valid)
            throw new InvalidEntityStateException(
                this, $"Post-checks failed in state {State}");
    }

    public enum ClassifiedAdState
    {
        PendingReview,
        Active,
        Inactive,
        MarkedAsSold
    }
}
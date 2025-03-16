using Marketplace.Domain;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace Marketplace.API;

public class ClassifiedAdRepository(IAsyncDocumentSession session) : IClassifiedAdRepository, IDisposable
{
    public Task<bool> Exists(ClassifiedAdId id) 
        => session.Advanced.ExistsAsync(EntityId(id));

    public Task<ClassifiedAd> Load(ClassifiedAdId id)
        => session.LoadAsync<ClassifiedAd>(EntityId(id));

    public async Task Save(ClassifiedAd entity)
    {
        await session.StoreAsync(entity, EntityId(entity.Id));
        await session.SaveChangesAsync();
    }

    public void Dispose() => session.Dispose();
        
    private static string EntityId(ClassifiedAdId id)
        => $"ClassifiedAd/{id}";
}
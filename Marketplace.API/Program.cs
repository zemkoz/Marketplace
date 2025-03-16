using Marketplace.API;
using Marketplace.Domain;
using Marketplace.Domain.Service;
using Raven.Client.Documents;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOpenApi()
    .AddControllers();

var store = new DocumentStore
{
    Urls = new[] {"http://localhost:8080"},
    Database = "MarketplaceDB",
    Conventions =
    {
        FindIdentityProperty = m => m.Name == "_databaseId"
    }
};
store.Conventions.RegisterAsyncIdConvention<ClassifiedAd>(
    (dbName, entity) => Task.FromResult("ClassifiedAd/" + entity.Id));
store.Initialize();
builder.Services.AddTransient(c => store.OpenAsyncSession());
builder.Services.AddTransient<IClassifiedAdRepository, ClassifiedAdRepository>();
builder.Services.AddTransient<ICurrencyLookup, FixedCurrencyLookup>();
builder.Services.AddSingleton<IApplicationService, ClassifiedAdsApplicationService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.MapOpenApi()
        .WithName("Classified Ads");
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Classified Ads V1");
    });
}

app.MapControllers();
app.UseHttpsRedirection();
app.Run();



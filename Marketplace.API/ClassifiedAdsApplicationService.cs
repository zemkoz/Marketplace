using Marketplace.API.Contract;
using Marketplace.Domain;
using Marketplace.Domain.Service;

namespace Marketplace.API;

public class ClassifiedAdsApplicationService(
    IClassifiedAdRepository classifiedAdRepository,
    ICurrencyLookup currencyLookup)
    : IApplicationService
{
    public async Task Handle(object command)
        {
            ClassifiedAd classifiedAd;
            switch (command)
            {
                case ClassifiedAds.V1.Create cmd:
                    if (await classifiedAdRepository.Exists(new ClassifiedAdId(cmd.Id)))
                        throw new InvalidOperationException(
                            $"Entity with id {cmd.Id} already exists");

                    classifiedAd = new ClassifiedAd(
                        new ClassifiedAdId(cmd.Id),
                        new UserId(cmd.OwnerId));

                    await classifiedAdRepository.Save(classifiedAd);
                    break;

                case ClassifiedAds.V1.UpdateTitle cmd:
                    classifiedAd = await classifiedAdRepository.Load(new ClassifiedAdId(cmd.Id));
                    if (classifiedAd == null)
                        throw new InvalidOperationException(
                            $"Entity with id {cmd.Id} cannot be found");

                    classifiedAd.UpdateTitle(ClassifiedAdTitle.FromString(cmd.Title));
                    await classifiedAdRepository.Save(classifiedAd);
                    break;

                case ClassifiedAds.V1.UpdateText cmd:
                    classifiedAd = await classifiedAdRepository.Load(new ClassifiedAdId(cmd.Id));
                    if (classifiedAd == null)
                        throw new InvalidOperationException(
                            $"Entity with id {cmd.Id} cannot be found");

                    classifiedAd.UpdateText(ClassifiedAdText.FromString(cmd.Text));
                    await classifiedAdRepository.Save(classifiedAd);
                    break;

                case ClassifiedAds.V1.UpdatePrice cmd:
                    classifiedAd = await classifiedAdRepository.Load(new ClassifiedAdId(cmd.Id));
                    if (classifiedAd == null)
                        throw new InvalidOperationException(
                            $"Entity with id {cmd.Id} cannot be found");

                    classifiedAd.UpdatePrice(
                        Price.FromDecimal(cmd.Price, cmd.Currency, currencyLookup));
                    await classifiedAdRepository.Save(classifiedAd);
                    break;

                case ClassifiedAds.V1.RequestToPublish cmd:
                    classifiedAd = await classifiedAdRepository.Load(new ClassifiedAdId(cmd.Id));
                    if (classifiedAd == null)
                        throw new InvalidOperationException(
                            $"Entity with id {cmd.Id} cannot be found");

                    classifiedAd.RequestToPublish();
                    await classifiedAdRepository.Save(classifiedAd);
                    break;

                default:
                    throw new InvalidOperationException(
                        $"Command type {command.GetType().FullName} is unknown");
            }
        }
}
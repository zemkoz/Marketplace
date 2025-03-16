using Marketplace.API.Contract;

namespace Marketplace.API;

public class CreateClassifiedAdHandler : IHandleCommand<ClassifiedAds.V1.Create>
{
    public void Handle(ClassifiedAds.V1.Create command)
    {
        switch (command)
        {
            case ClassifiedAds.V1.Create cmd:
                // we need to create a new Classified Ad here
                break;

            default:
                throw new InvalidOperationException(
                    $"Command type {command.GetType().FullName} is unknown");
        }
    }
}
namespace Marketplace.API;

public interface IApplicationService
{
    Task Handle(object command);
}
namespace Marketplace.API;

public interface IHandleCommand<in T>
{
    void Handle(T command);
}
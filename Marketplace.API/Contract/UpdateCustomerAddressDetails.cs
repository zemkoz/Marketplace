namespace Marketplace.API.Contract;

public class UpdateCustomerAddressDetails
{
    public Address BillingAddress { get; set; }
    public Address DeliveryAddress { get; set; }
}
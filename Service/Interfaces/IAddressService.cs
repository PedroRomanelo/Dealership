namespace Dealership.Service.Interfaces;

public interface IAddressService
{
    Task() GetActiveAddressByUserIdAsync(int userId);
    Task() CreateOrReplaceAsync(int userId, CreateAddressRequest request);
}

using Dealership.Model.Request.Address;

namespace Dealership.Service.Interfaces;

public interface IAddressService
{
    Task<int> CreateAsync (AddressCreateRequest request);
    Task<bool> UpdateAsync(int id, AddressUpdateRequest request);
    Task<bool> DeactivateByUserIdAsync(int userId);
}
using Microsoft.AspNetCore.Identity.Data;

namespace Dealership.Service.Interfaces;

public interface IAddressService
{
    Task<int> CreateAsync (LoginRequest request);
    //Task CreateOrReplaceAsync(int userId, CreateAddressRequest request);
}

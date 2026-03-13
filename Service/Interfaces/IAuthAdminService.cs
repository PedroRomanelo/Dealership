using Microsoft.AspNetCore.Identity.Data;

namespace Dealership.Service.Interfaces;

public interface IAuthAdminService
{
    Task<> CreateAsync(CreateAdminUserRequest request);
    Task<> LoginAsync(LoginRequest request);
    Task<> RecoverPasswordAsync(string email);
}

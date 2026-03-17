using Dealership.Model.Response.User;
using Dealership.Model.Request.User;

namespace Dealership.Service.Interfaces;

public interface IUserService
{
    Task<UserResponseVM?> GetByDocumentAsync(string document);
    Task<UserResponseVM?> GetByEmailAsync(string email);
    Task<UserResponseVM> CreateAsync(UserRegisterVM request);
    Task<UserResponseVM> UpdateAsync(int id, UserUpdateVM request);
    Task<bool> DeactivateAsync(int id);
}

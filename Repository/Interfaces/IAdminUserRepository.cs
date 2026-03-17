using Dealership.Model.Entities;

namespace Dealership.Repository.Interfaces;

public interface IAdminUserRepository
{
    Task<int> CreateAsync(AdminUsers adminUsers);
    Task<bool> UpdatePasswordAsync(int id, string newPasswordHash);
    //LOGIN ?
    Task<AdminUsers?> GetByLoginAsync(string Login);
}

using Dealership.Model.Entities;

namespace Dealership.Repository.Interfaces;

public interface IUserRepository
{
    Task<int> CreateAsync(Users user);
    Task<bool> UpdateAsync(Users user);
    Task<bool> DeactivateAsync(int Id);
    Task<bool> ReactivateAsync(int Id);
    Task<IEnumerable<Users>> GetByDocumentAsync(string document);
    Task<IEnumerable<Users>> GetByEmailAsync(string email);
}
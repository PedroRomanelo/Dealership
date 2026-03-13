namespace Dealership.Service.Interfaces;

public interface IUserService
{
    Task() GetByDocumentAsync(string document);
    Task() GetByEmailAsync(string email);
    Task() CreateAsync(CreateUserRequest request);
    Task() UpdateAsync(int id, UpdateUserRequest request);
    Task() DeactivateAsync(int id);
}

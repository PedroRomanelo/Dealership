using Dealership.Model.Entities;

namespace Dealership.Service.Interfaces;

public interface ITokenService
{
    public string GenerateToken(AdminUsers admin);
}

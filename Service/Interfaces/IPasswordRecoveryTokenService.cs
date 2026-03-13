using Dealership.Model.Entities;

namespace Dealership.Service.Interfaces;

public interface IPasswordRecoveryTokenService
{
    string GenerateRecoveryToken(AdminUsers admin);
}

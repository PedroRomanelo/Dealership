using Dealership.Model.Entities;

namespace Dealership.Repository.Interfaces;

public interface IAddressRepository
{
    Task<int> CreateAsync(UserAddress address); //retorna id
    Task<bool> UpdateAsync(UserAddress address); //retorna sucesso ou falha
    Task<bool> DeactivateByUserIdAsync(int userId);
    Task<bool> ReactivateByUserIdAsync(int  userId);
}

//métodos (nome, parâmetros e tipo de retorno)
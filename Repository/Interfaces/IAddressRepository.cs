using Dealership.Model.Entities;

namespace Dealership.Repository.Interfaces;

public interface IAddressRepository
{
    Task<int?> CreateAsync(UserAddresses address); //retorna id
    Task<bool> UpdateAsync(UserAddresses address); //retorna sucesso ou falha
    Task<bool> DeactivateByUserIdAsync(int userId);
    Task<bool> ReactivateByUserIdAsync(int  userId);
    Task<UserAddresses?> GetByIdAsync(int id);
}

//métodos (nome, parâmetros e tipo de retorno)
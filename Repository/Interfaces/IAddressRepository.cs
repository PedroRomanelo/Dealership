using Dealership.Model.Entities;

namespace Dealership.Repository.Interfaces;

public interface IAddressRepository
{
    Task<int> InsertAsync(UserAddress address); //retorna id
    Task<bool> UpdateAsync(UserAddress address); //retorna sucesso ou falha
}

//métodos (nome, parâmetros e tipo de retorno)
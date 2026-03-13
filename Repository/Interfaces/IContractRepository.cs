
using Dealership.Model.Entities;

namespace Dealership.Repository.Interfaces;

public interface IContractRepository
{
    Task<int> InsertAsync(Contracts contract);
    Task<IEnumerable<Contracts>> GetAllAsync(); //retorna a coleção da tab. contracts
}


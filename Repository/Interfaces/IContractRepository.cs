using Dealership.Model.Entities;
using Dealership.Model.Request;

public interface IContractRepository
{
    Task<int> InsertAsync(Contracts contract);
}

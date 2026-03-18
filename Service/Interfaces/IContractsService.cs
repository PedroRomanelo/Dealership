using Dealership.Model.Request.Contract;
using Dealership.Model.Response.Contract;

namespace Dealership.Service.Interfaces;

public interface IContractsService
{
    Task<ContractResponseVM> ViewContractAsync(ContractRequestVM request);
    Task<int> CreateContractAsync(ContractRequestVM request);
}
using Dealership.Model.Request.Rental;
using Dealership.Model.Response.Rental;

namespace Dealership.Service.Interfaces;

public interface IReportService
{
    Task<ContractSimulationVM> SimulateContractAsync(ContractRequestVM request);
    Task<int> CreateContractAsync(ContractRequestVM request);
}
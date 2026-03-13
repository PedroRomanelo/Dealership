namespace Dealership.Service.Interfaces;

public interface IContractsService
{
    Task() PreviewAsync(ContractRequest request);
    Task() CreateAsync(ContractRequest request);
}
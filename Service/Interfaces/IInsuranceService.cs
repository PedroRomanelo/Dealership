namespace Dealership.Service.Interfaces;

public interface IInsuranceService
{
    Task() GetByModelIdAsync(int modelId);
    Task() CreateAsync(CreateInsuranceRequest request, string userProfile);
    Task() UpdateAsync(int id, UpdateInsuranceRequest request, string userProfile);
}

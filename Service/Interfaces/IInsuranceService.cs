using Dealership.Model.Request.Insurance ;
using Dealership.Model.Response.insurance;

namespace Dealership.Service.Interfaces;

public interface IInsuranceService
{
    Task<int> CreateAsync(InsuranceCreateVM request);
    Task<bool> UpdateAsync(int id, InsuranceUpdateVM request);
    Task<IEnumerable<InsuranceResponseVM>> GetByModelIdAsync(int modelId);
}

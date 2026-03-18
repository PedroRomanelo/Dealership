using Dealership.Model.Entities;
using Dealership.Model.Request.Insurance;
using Dealership.Model.Response.insurance;
using Dealership.Repository.Interfaces;
using Dealership.Service.Interfaces;

namespace Dealership.Service.Implementations;

public class InsuranceService : IInsuranceService
{
    private readonly IInsuranceRepository _insuranceRepository;

    public InsuranceService(IInsuranceRepository insuranceRepository)
    {
        _insuranceRepository = insuranceRepository;
    }

    public async Task<int> CreateAsync(InsuranceCreateVM request)
    {
        var entity = new Insurance
        {
            Description = request.Description,
            ModelId = request.ModelId,
            DailyRate = request.DailyRate
        };

        return await _insuranceRepository.InsertAsync(entity);
    }

    public async Task<bool> UpdateAsync(int id, InsuranceUpdateVM request)
    {
        var entity = new Insurance
        {
            Id = id,
            Description = request.Description,
            ModelId = request.ModelId,
            DailyRate = request.DailyRate
        };

        return await _insuranceRepository.UpdateAsync(entity);
    }

    public async Task<IEnumerable<InsuranceResponseVM>> GetByModelIdAsync(int modelId)
    {
        var insurances = await _insuranceRepository.GetByModelAsync(modelId);

        return insurances.Select(i => new InsuranceResponseVM
        {
            Description = i.Description,
            ModelId = i.ModelId,
            DailyRate = i.DailyRate
        });
    }

}
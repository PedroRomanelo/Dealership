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
        var entity = await _insuranceRepository.GetByIdAsync(id);

        if (entity == null)
            throw new Exception("Seguro não encontrado.");
        
        if(request.Description != null)
            entity.Description = request.Description;

        if (request.ModelId.HasValue)
            entity.ModelId = request.ModelId.Value;

        if (request.DailyRate.HasValue)
            entity.DailyRate = request.DailyRate.Value;

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
using Dealership.Model.Entities;
using Dealership.Model.Request.Model;
using Dealership.Model.Response.modeL;
using Dealership.Repository.Implementations;
using Dealership.Repository.Interfaces;
using Dealership.Service.Interfaces;

namespace Dealership.Service.Implementations;

public class ModelsService : IModelsService
{
    private readonly IModelRepository _modelRepository;

    public ModelsService(IModelRepository modelRepository)
    {
        _modelRepository = modelRepository;
    }

    public async Task<ModelResponseVM> CreateAsync(ModelRegisterVM request)
    {
        var modelEntity = new Models
        {
            Model = request.Model,
            Brand = request.Brand,
            Status = true
        };

        modelEntity.Id = await _modelRepository.CreateAsync(modelEntity);
        return MapToResponse(modelEntity);
    }

    public async Task<ModelResponseVM> UpdateAsync(int id, ModelUpdate request)
    {
        var modelEntity = new Models
        {
            Id = id,
            Model = request.Model,
            Brand = request.Brand,
            Status = true
        };

        bool updated = await _modelRepository.UpdateAsync(modelEntity);
        if (!updated) throw new Exception("Modelo não encontrado.");

        return MapToResponse(modelEntity);
    }

    public async Task<IEnumerable<ModelResponseVM>> GetByModelAsync(string modelName)
    {
        var models = await _modelRepository.GetByModelAsync(modelName);

        return models.Select(m => MapToResponse(m));
    }

    public async Task<IEnumerable<ModelResponseVM>> GetByBrandAsync(string brand)
    {
        var models = await _modelRepository.GetByBrandAsync(brand);
        return models.Select(m => MapToResponse(m));
    }

    public async Task<bool> DeactivateAsync(int id)
    {
        return await _modelRepository.DeactivateAsync(id);
    }

    private ModelResponseVM MapToResponse(Models entity)
    {
        return new ModelResponseVM
        {
            Model = entity.Model,
            Brand = entity.Brand
        };
    }
}

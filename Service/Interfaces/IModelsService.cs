using Dealership.Model.Response.modeL;
using Dealership.Model.Request.Model;

namespace Dealership.Service.Interfaces;

public interface IModelsService
{
    Task<ModelResponseVM> CreateAsync(ModelRegisterVM request);
    Task<ModelResponseVM> UpdateAsync(int id, ModelUpdateVM request);
    Task<IEnumerable<ModelResponseVM>> GetByModelAsync(string modelName);
    Task<IEnumerable<ModelResponseVM>> GetByBrandAsync(string Brand);
    Task<bool> DeactivateAsync(int id);
}

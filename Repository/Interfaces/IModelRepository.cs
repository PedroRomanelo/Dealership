using Dealership.Model.Entities;

namespace Dealership.Repository.Interfaces;

public interface IModelRepository
{
    Task<int> CreateAsync(Models model);
    Task<bool> UpdateAsync(Models model);
    Task<bool> DeactivateAsync(int Id );
    Task<bool> ReactivateAsync(int Id);
    Task<IEnumerable<Models>> GetByModelAsync(string modelName);
    Task<IEnumerable<Models>> GetByBrandAsync(string modelName);
    Task<Models> GetByIdAsync(int id);
}
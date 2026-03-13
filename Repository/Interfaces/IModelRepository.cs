using Dealership.Model.Entities;

namespace Dealership.Repository.Interfaces;

public interface IModelRepository
{
    Task<int> CreateAsync(Models model);
    Task<bool> UpdateAsync(Models model);
    Task<bool> DeactivateAsync(int ModelId );
    Task<bool> ReactivateAsync(int ModelId);
    Task<IEnumerable<Models>> GetByModelAsync(int Id);
    Task<IEnumerable<Models>> GetByBrandAsync(int Id);
}
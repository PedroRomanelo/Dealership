using Dealership.Model.Entities;
using Dealership.Model.Request;

namespace Dealership.Repository.Interfaces;

public interface IVehicleRepository
{
    Task<int> CreateAsync(Vehicles vehicle);
    Task<int> UpdateAsync(Vehicles vehicle);
    Task<bool> DeactivateAsync(int id);
    Task<bool> ReactivateAsync(int id);
    Task<IEnumerable<Vehicles>> GetByPlateAsync(string plate);
    Task<IEnumerable<Vehicles>> GetByModelAsync(int modelId);
}
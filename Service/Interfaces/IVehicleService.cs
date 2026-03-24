using Dealership.Model.Request.Vehicle;
using Dealership.Model.Response.Vehicle;

namespace Dealership.Service.Interfaces;

public interface IVehicleService
{
    Task<int> CreateAsync(VehicleCreateVM request);
    Task<bool> UpdateAsync(int id, VehicleUpdateVM request);
    Task<bool> DeactivateAsync(int id);
    Task<VehicleResponseVM?> GetByPlateAsync(string plate);
    Task<IEnumerable<VehicleResponseVM>> GetByModelIdAsync(int modelId);
}
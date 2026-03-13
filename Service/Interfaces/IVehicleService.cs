namespace Dealership.Service.Interfaces;

public interface IVehicleService
{
    Task() GetByPlateAsync(string plate);
    Task() GetByModelIdAsync(int modelId);
    Task() CreateAsync(CreateVehicleRequest request);
    Task() UpdateAsync(int id, UpdateVehicleRequest request);
    Task() DeactivateAsync(int id);
}

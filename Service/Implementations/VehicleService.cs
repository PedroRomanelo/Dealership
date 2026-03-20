using Dealership.Model.Entities;
using Dealership.Model.Request.Vehicle;
using Dealership.Model.Response.Vehicle;
using Dealership.Repository.Interfaces;
using Dealership.Service.Interfaces;

namespace Dealership.Service.Implementations;

public class VehicleService : IVehicleService
{
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleService(IVehicleRepository vehileRepository)
    {
        _vehicleRepository = vehileRepository;
    }

    public async Task<int> CreateAsync(VehicleCreateVM request)
    {
        var entity = new Vehicles
        {
            LicensePlate = request.LicensePlate,
            ModelId = request.ModelId,
            Mileage = request.Mileage,
            DailyRate = request.DailyRate
        };

        return await _vehicleRepository.CreateAsync(entity);
    }

    public async Task<bool> UpdateAsync(int id, VehicleUpdateVM request)
    {
        var entity = await _vehicleRepository.GetByIdAsync(id);
        if (entity == null)
            throw new Exception("O Id não foi encontrado.");

        if(request.LicensePlate != null)
            entity.LicensePlate = request.LicensePlate;

        if (request.ModelId.HasValue)
            entity.ModelId = request.ModelId.Value;

        if(request.Mileage.HasValue)
            entity.Mileage = request.Mileage.Value;

        if(request.DailyRate.HasValue)
            entity.DailyRate = request.DailyRate.Value;

        return await _vehicleRepository.UpdateAsync(entity) > 0;
    }

    public async Task<bool> DeactivateAsync(int id)
    {
        return await _vehicleRepository.DeactivateAsync(id);
    }

    public async Task<IEnumerable<VehicleResponseVM>> GetByPlateAsync(string plate)
    {
        var vehicles = await _vehicleRepository.GetByPlateAsync(plate);
        return MapToResponse(vehicles);
    }

    public async Task<IEnumerable<VehicleResponseVM>> GetByModelIdAsync(int modelId)
    {
        var vehicles = await _vehicleRepository.GetByModelAsync(modelId);
        return MapToResponse(vehicles);
    }

    private IEnumerable<VehicleResponseVM> MapToResponse(IEnumerable<Vehicles> entities)
    {
        return entities.Select(v => new VehicleResponseVM
        {
            LicensePlate = v.LicensePlate,
            ModelId = v.ModelId,
            Mileage = v.Mileage,
            DailyRate = v.DailyRate
        });
    }
}
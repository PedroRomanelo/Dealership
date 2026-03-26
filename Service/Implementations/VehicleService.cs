using Dealership.Cache;
using Dealership.Model.Entities;
using Dealership.Model.Request.Vehicle;
using Dealership.Model.Response.Vehicle;
using Dealership.Repository.Interfaces;
using Dealership.Service.Interfaces;

namespace Dealership.Service.Implementations;

public class VehicleService : IVehicleService
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly ICacheService _cache;

    public VehicleService(IVehicleRepository vehileRepository, ICacheService cache)
    {
        _vehicleRepository = vehileRepository;
        _cache = cache;
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

    public async Task<VehicleResponseVM> GetByPlateAsync(string plate)
    {
        var cacheKey = $"vehicle:{plate}";

        var cached = await _cache.GetAsync<VehicleResponseVM>(cacheKey);
        if (cached is not null)
            return cached;

        var vehicle = await _vehicleRepository.GetByPlateAsync(plate);
        if (vehicle == null) return null;

        var response = MapToResponse(vehicle);
        await _cache.SetAsync(cacheKey, response, TimeSpan.FromMinutes(5)); 

        return response;
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

    private VehicleResponseVM MapToResponse(Vehicles v)
    {
        return new VehicleResponseVM
        {
            LicensePlate = v.LicensePlate,
            ModelId = v.ModelId,
            Mileage = v.Mileage,
            DailyRate = v.DailyRate
        };
    }
}
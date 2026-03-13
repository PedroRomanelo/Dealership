using Dapper;
using Dealership.Model.Entities;
using Dealership.Repository.Interfaces;

namespace Dealership.Repository.Implementations;
    public class VehicleRepository(string connectionString): BaseRepository(connectionString), IVehicleRepository
{
    public async Task<int> CreateAsync(Vehicles vehicle)
    {
        using var db = CreateConnection();

        const string sql = @"
            INSERT INTO Vehicles (LicensePlate, ModelId, Mileage, DailyRate, IsActive)
            VALUES (@LicensePlate, @ModelId, @Mileage, @DailyRate, 1);
            
            SELECT CAST(SCOPE_IDENTITY() AS INT);";

        return await db.ExecuteScalarAsync<int>(sql, vehicle);
    }

    public async Task<int> UpdateAsync(Vehicles vehicle)
    {
        using var db = CreateConnection();

        const string sql = @"
            UPDATE Vehicles
            SET LicensePlate = @LicensePlate, 
                ModelId = @ModelId, 
                Mileage = @Mileage, 
                DailyRate = @DailyRate
            WHERE Id = @Id";

        return await db.ExecuteAsync(sql, vehicle);
    }

    public async Task<bool> DeactivateAsync(int id)
    {
        using var db = CreateConnection();

        const string sql = @"
            UPDATE Vehicles 
            SET IsActive = 0 
            WHERE Id = @Id";

        int rowsAffected = await db.ExecuteAsync(sql, new { Id = id });
        return rowsAffected > 0;
    }

    public async Task<bool> ReactivateAsync(int id)
    {
        using var db = CreateConnection();

        const string sql = @"
            UPDATE Vehicles 
            SET IsActive = 1 
            WHERE Id = @Id";

        int rowsAffected = await db.ExecuteAsync(sql, new { Id = id });
        return rowsAffected > 0;
    }

    public async Task<IEnumerable<Vehicles>> GetByPlateAsync(string plate)
    {
        using var db = CreateConnection();

        const string sql = @"SELECT * FROM Vehicles WHERE LicensePlate = @Plate";

        return await db.QueryAsync<Vehicles>(sql, new { Plate = plate });
    }

    public async Task<IEnumerable<Vehicles>> GetByModelAsync(int modelId)
    {
        using var db = CreateConnection();

        const string sql = @"SELECT * FROM Vehicles WHERE ModelId = @ModelId";

        return await db.QueryAsync<Vehicles>(sql, new { ModelId = modelId });
    }
}
using Dapper;
using Dealership.Model.Entities;
using Dealership.Repository.Interfaces;

namespace Dealership.Repository.Implementations;

public class InsuranceRepository(string connectionString) : BaseRepository(connectionString), IInsuranceRepository
{
    public async Task<int> InsertAsync(Insurance insurance)
    {
        using var db = CreateConnection();

        string sql = @"
            INSERT INTO Insurances (Description, ModelId, DailyRate)
            VALUES (@Description, @ModelId, @DailyRate);
            SELECT CAST(SCOPE_IDENTITY() AS INT);";

        return await db.ExecuteScalarAsync<int>(sql, insurance);
    }

    public async Task<bool> UpdateAsync (Insurance insurance)
    {
        using var db = CreateConnection();

        string sql = @"
        UPDATE Insurances 
        SET Description = @Description, ModelId = @ModelId, DailyRate = @DailyRate;
        WHERE Id = @Id
        ";
        int rowsAffected = await db.ExecuteAsync(sql, insurance);
        return rowsAffected > 0;
    }

    public async Task<IEnumerable<Insurance>> GetByModelAsync(int modelId)
    {
        using var db = CreateConnection();

        string sql = @"
            SELECT * FROM Insurances WHERE @ModelId = ModelId
        ";

        return await db.QueryAsync<Insurance>(sql, modelId);
    }
}
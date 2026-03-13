using Dapper;
using Dealership.Model.Entities;
using Dealership.Model.Request;
using Dealership.Repository.Interfaces;

namespace Dealership.Repository.Implementations;
public class ModelRepository(string connectionString) : BaseRepository(connectionString), IModelRepository
{
    public async Task<int> CreateAsync(Models model)
    {
        using var db = CreateConnection();

        string sql = @"
            INSERT INTO Models (Model, Brand, Status)
            SET (@Model, @Brand, @Status);
            SELECT CAST(SCOPE_IDENTITY() AS INT);";

        return await db.ExecuteScalarAsync<int>(sql, model);
    }

    public async Task<bool> UpdateAsync(Models model)
    {
        using var db = CreateConnection();

        string sql = @"
        UPDATE Models
        SET Model = @Model, Brand = @Brand, Status = @Status
        Where Id = @Id";

        int rowsAffected = await db.ExecuteAsync(sql, model);
        return rowsAffected > 0;
    }

    public async Task<bool> DeactivateAsync(int Id)
    {
        using var db = CreateConnection();

        string sql = @"
        UPDATE Models
        SET Status = 0 
        WHERE Id = @Id";

        int rowsAffected = await db.ExecuteAsync(sql, Id);
        return rowsAffected > 0;
    }

    public async Task<bool> ReactivateAsync(int Id)
    {
        using var db = CreateConnection();

        string sql = @"
        UPDATE Models
        SET Status = 1
        WHERE Id = @Id";

        int rowsAffected = await db.ExecuteAsync(sql, Id);
        return rowsAffected > 0;
    }

    public async Task<IEnumerable<Models>> GetByModelAsync(int Id)
    {
        using var db = CreateConnection();

        string sql = @" SELECT * FROM Models WHERE Model = @Model ";

        return await db.QueryAsync<Models>(sql, Id);
    }

    public async Task<IEnumerable<Models>> GetByBrandAsync(int Id)
    {
        using var db = CreateConnection();

        string sql = @" SELECT * FROM Models WHERE Brand = @Brand ";

        return await db.QueryAsync<Models>(sql, Id);
    }
}

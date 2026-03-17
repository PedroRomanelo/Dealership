using Dapper;
using Dealership.Model.Entities;
using Dealership.Model.Request;
using Dealership.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Dealership.Repository.Implementations;
public class ModelRepository(string connectionString) : BaseRepository(connectionString), IModelRepository
{
    public async Task<int> CreateAsync(Models model)
    { 
        using var db = CreateConnection();

        string sql = @"
            INSERT INTO Models (Model, Brand)
            VALUES (@Model, @Brand);
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

    public async Task<bool> DeactivateAsync(int id)
    {
        using var db = CreateConnection();

        string sql = @"
        UPDATE Models
        SET Status = 0 
        WHERE Id = @Id";

        int rowsAffected = await db.ExecuteAsync(sql, new { Id = id });
        return rowsAffected > 0;
    }

    public async Task<bool> ReactivateAsync(int id)
    {
        using var db = CreateConnection();

        string sql = @"
        UPDATE Models
        SET Status = 1
        WHERE Id = @Id";

        int rowsAffected = await db.ExecuteAsync(sql, new { Id = id });
        return rowsAffected > 0;

        //da pra resumir as duas linhas acima: return await db.ExecuteAsync(sql, model) > 0;
    }

    public async Task<IEnumerable<Models>> GetByModelAsync(string modelName)
    {
        using var db = CreateConnection();

        string sql = @" SELECT * FROM Models WHERE Model LIKE @Model ";

        return await db.QueryAsync<Models>(sql, new { Model = $"%{modelName}%" });
    }

    public async Task<IEnumerable<Models>> GetByBrandAsync(string brandName)
    {
        using var db = CreateConnection();

        string sql = @" SELECT * FROM Models WHERE Brand = @Brand ";

        return await db.QueryAsync<Models>(sql, new { Brand = brandName });
    }
}

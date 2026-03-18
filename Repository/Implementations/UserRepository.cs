using Dapper;
using Dealership.Model.Entities;
using Dealership.Repository.Interfaces;

namespace Dealership.Repository.Implementations;

public class UserRepository(string connectionString ):BaseRepository(connectionString), IUserRepository
{
    public async Task<int> CreateAsync(Users user)
    {
        using var db = CreateConnection();

        string sql = @"
        INSERT INTO Users ( Name, Document, Email, PhoneNumber, BirthDate)
        VALUES (@Name, @Document, @Email, @PhoneNumber, @BirthDate);
        SELECT CAST (SCOPE_IDENTITY() AS INT);";

        return await db.ExecuteScalarAsync<int>(sql, user);
    }

    public async Task<bool> UpdateAsync(Users user)
    {
        using var db = CreateConnection();

        string sql = @"
        UPDATE Users
        SET Name = @Name, Document = @Document, Email = @Email, PhoneNumber = @PhoneNumber, BirthDate = @BirthDate
        WHERE Id = @Id";

        int rowsAffected = await db.ExecuteAsync(sql, user);
        return rowsAffected > 0;
    }

    public async Task<bool> DeactivateAsync(int id)
    {
        using var db = CreateConnection();

        string sql = @"
        UPDATE Users
        SET Status = 0 
        WHERE Id = @Id";

        int rowsAffected = await db.ExecuteAsync(sql, new { Id = id });
        return rowsAffected > 0;
    }

    public async Task<bool> ReactivateAsync(int id)
    {
        using var db = CreateConnection();

        string sql = @"
        UPDATE Users
        SET Status = 1 
        WHERE Id = @Id";

        int rowsAffected = await db.ExecuteAsync(sql, new { Id = id });
        return rowsAffected > 0;
    }

    public async Task<Users?> GetByDocumentAsync(string document)
    {
        using var db = CreateConnection();

        string sql = "SELECT * FROM Users WHERE Document = @Document"; //query sem qubra de linha nn precisa de @

        return await db.QueryFirstOrDefaultAsync<Users>(sql, new { Document = document });
    }

    public async Task<Users?> GetByEmailAsync(string email)
    {
        using var db = CreateConnection();

        string sql = "SELECT * FROM Users WHERE Email = @Email";

        return await db.QueryFirstOrDefaultAsync<Users>(sql, new { Email = email });
    }

    public async Task<Users?> GetByIdAsync(int id)
    {
        using var db = CreateConnection();

        string sql = "SELECT * FROM Users WHERE Id = @Id";

        return await db.QueryFirstOrDefaultAsync<Users>(sql, new { Id = id });
    }

}


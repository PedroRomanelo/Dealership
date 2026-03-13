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
        INSERT INTO Users ( Name, Document, Email, PhoneNumber, BirthDate, Status)
        VALUE (@Name, @Document, @Email, @PhoneNumber, @BirthDate, @Status);
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

    public async Task<bool> DeactivateAsync(int Id)
    {
        using var db = CreateConnection();

        string sql = @"
        UPDATE Users
        SET Status = 0 
        WHERE Id = @Id";

        int rowsAffected = await db.ExecuteAsync(sql, Id);
        return rowsAffected > 0;
    }

    public async Task<bool> ReactivateAsync(int Id)
    {
        using var db = CreateConnection();

        string sql = @"
        UPDATE Users
        SET Status = 1 
        WHERE Id = @Id";

        int rowsAffected = await db.ExecuteAsync(sql, Id);
        return rowsAffected > 0;
    }

    public async Task<IEnumerable<Users>> GetByDocumentAsync(string document)
    {
        using var db = CreateConnection();

        string sql = "SELECT * FROM Users WHERE Document = @Document"; //query sem qubra de linha nn precisa de @

        return await db.QueryAsync <Users>(sql, new { Document = document });
    }

    public async Task<IEnumerable<Users>> GetByEmailAsync(string email)
    {
        using var db = CreateConnection();

        string sql = "SELECT * FROM Users WHERE email = @email";

        return await db.QueryAsync<Users>(sql, new { Email = email });
    }


}


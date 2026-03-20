using Dapper;
using Dealership.Model.Entities;
using Dealership.Repository.Interfaces;

namespace Dealership.Repository.Implementations;
public class AddressRepository(string connectionString) : BaseRepository(connectionString), IAddressRepository
{
    public async Task<int?> CreateAsync( UserAddresses address)
    {
        string sql = @"
            INSERT INTO UserAddresses (UserId, State, City, Street, Number)
            SELECT @UserId, @State, @City, @Street, @Number
                WHERE NOT EXISTS(
                    SELECT 1
                    FROM UserAddresses
                    WHERE UserId = @UserId
                    AND Status = 1
                );

            SELECT CAST(SCOPE_IDENTITY() as int);";

        return await _conn.ExecuteScalarAsync<int?>( sql, address);
    }

    public async Task<bool> UpdateAsync(UserAddresses address)
    {
        using var db = CreateConnection();

        string sql = @"
            UPDATE UserAddresses
            SET UserId = @UserId, State = @State, City = @City, Street = @Street, Number = @Number, Status = @Status
            WHERE Id = @Id";

        int rowsAffected = await db.ExecuteAsync(sql, address);
        return rowsAffected > 0;
    }

    public async Task<bool> DeactivateByUserIdAsync(int userId) {
        using var db = CreateConnection();

        string sql = @"
            UPDATE UserAddresses
            SET Status = 0
            WHERE UserId = @userId";

        int rowsAffected = await db.ExecuteAsync(sql, new { userId });
        return rowsAffected > 0;
    }

    public async Task<bool> ReactivateByUserIdAsync(int userId)
    {
        using var db = CreateConnection();

        const string sql = @"
        UPDATE UserAddresses
        SET Status = 1
        WHERE UserId = @userId";

        int rowsAffected = await db.ExecuteAsync(sql, new { userId });
        return rowsAffected > 0;
    }
    public async Task<UserAddresses?> GetByIdAsync(int id)
    {
        using var db = CreateConnection();

        string sql = "SELECT * FROM UserAddresses WHERE Id = @Id";

        return await db.QueryFirstOrDefaultAsync<UserAddresses>(sql, new { Id = id });
    }
}
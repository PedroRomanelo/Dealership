using Dapper;
using Dealership.Model.Entities;
using Dealership.Repository.Interfaces;

namespace Dealership.Repository.Implementations;
public class AddressRepository(string connectionString) : BaseRepository(connectionString), IAddressRepository
{
    public async Task<int> CreateAsync( UserAddress address)
    {
        using var db = CreateConnection();

        string sql = @"
            INSERT INTO UserAddress (UserId, State, City, Street, Number, Status)
            VALUES (@UserId, @State, @City, @Street, @Number, @Status );

            SELECT CAST(SCOPE_IDENTITY() as int);";

        return await db.ExecuteScalarAsync<int>( sql, address);
    }

    public async Task<bool> UpdateAsync(UserAddress address)
    {
        using var db = CreateConnection();

        string sql = @"
            UPDATE UserAddress 
            SET UserId = @UserId, State = @State, City = @City, Street = @Street, Number = @Number, Status = @Status
            WHERE Id = @Id";

        int rowsAffected = await db.ExecuteAsync(sql, address);
        return rowsAffected > 0;
    }

    public async Task<bool> DeactivateByUserIdAsync(int userId) {
        using var db = CreateConnection();

        string sql = @"
            UPDATE UserAddress
            SET Status = 0
            WHERE UserId = @userId";

        int rowsAffected = await db.ExecuteAsync(sql, new { userId });
        return rowsAffected > 0;
    }

    public async Task<bool> ReactivateByUserIdAsync(int userId)
    {
        using var db = CreateConnection();

        const string sql = @"
        UPDATE UserAddress 
        SET Status = 1
        WHERE UserId = @userId";

        int rowsAffected = await db.ExecuteAsync(sql, new { userId });
        return rowsAffected > 0;
    }
}
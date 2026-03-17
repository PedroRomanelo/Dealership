using Dapper;
using Dealership.Model.Entities;
using Dealership.Repository.Interfaces;

namespace Dealership.Repository.Implementations;
public class PaymentMethodRepository(string connectionString) : BaseRepository(connectionString), IPaymentMethodRepository
{
    public async Task<int> CreateAsync(PaymentMethod paymentMethod) 
    {
        using var db = CreateConnection();

        string sql = @"
        INSERT INTO PaymentMethod ( Description, Name)
        VALUES (@Description, @Name)
        SELECT CAST(SCOPE_IDENTITY() as int);";

        return await db.ExecuteScalarAsync<int>(sql, paymentMethod);
    }

    public async Task<bool> UpdateAsync(PaymentMethod paymentMethod)
    {
        using var db = CreateConnection();

        string sql = @"
        UPDATE PaymentMethod
        SET Description = @Description, Status = @Status, Name = @Name
        WHERE Id = @Id
        ";

        int rowsAffected = await db.ExecuteAsync(sql, paymentMethod);
        return rowsAffected > 0;
    }

    public async Task<bool> DeactivateAsync(int Id)
    {
        using var db = CreateConnection();

        string sql = @"
        UPDATE PaymentMethod
        SET Status = 0 
        WHERE Id = @Id";

        int rowsAffected = await db.ExecuteAsync(sql, new { Id = Id });
        return rowsAffected > 0;
    }

    public async Task<bool> ReactivateAsync(int Id)
    {
        using var db = CreateConnection();

        string sql = @"
        UPDATE PaymentMethod
        SET Status = 1
        WHERE Id = @Id";

        int rowsAffected = await db.ExecuteAsync(sql, Id);
        return rowsAffected > 0;
    }

    public async Task<IEnumerable<PaymentMethod>> GetAllAsync()
    {
        using var db = CreateConnection();

        string sql = @" SELECT * FROM PaymentMethod ";

        return await db.QueryAsync<PaymentMethod>(sql);
    }
}

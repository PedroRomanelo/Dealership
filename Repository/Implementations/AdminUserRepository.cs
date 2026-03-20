using Dapper;
using Dealership.Model.Entities;
using Dealership.Repository.Interfaces;

namespace Dealership.Repository.Implementations;

public class AdminUserRepository(string connectionString): BaseRepository(connectionString), IAdminUserRepository
{
    public async Task<int> CreateAsync(AdminUsers adminUsers)
    {
        using var db = CreateConnection();

        string sql = @"
        INSERT INTO AdminUsers (Login, Password, Role)
        VALUES (@Login, @Password, @Role);

        SELECT CAST (scope_identity() as int);"; //pega o ultimo id gerado no mesmo escopo(scope), evita pegar id errado em trigger
        //
        return await db.ExecuteScalarAsync<int>(sql, adminUsers);
    }

    public async Task<bool> UpdatePasswordAsync(int id, string newPassword)
    {
        using var db = CreateConnection();

        string sql = @"
        UPDATE AdminUsers
        SET Password = @Password
        WHERE Id = @Id";

        int rowsAffected = await db.ExecuteAsync(sql, new { Id = id, Password = newPassword });
        return rowsAffected > 0; //retorna true quando afeta
    }

    public async Task<AdminUsers?> GetByLoginAsync(string login)
    {
        using var db = CreateConnection();

        string sql = @"
        SELECT *
        FROM AdminUsers
        WHERE Login = @Login";

        return await db.QueryFirstOrDefaultAsync<AdminUsers>(sql, new { Login = login });
    }
}
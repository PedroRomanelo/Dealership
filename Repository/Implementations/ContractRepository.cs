using Dapper;
using Dealership.Model.Entities;
using Dealership.Repository.Interfaces;

namespace Dealership.Repository.Implementations;
public class ContractRepository(string connectionString) : BaseRepository(connectionString), IContractRepository
{
    public async Task<int> InsertAsync(Contracts number)
    {
        using var db = CreateConnection();

        string sql = @"
            INSERT INTO Contracts (ContractNumber, UserId, ContractData, ContractStartData, ContractEndData, Insurance, TotalPrice, PaymentMethod)
            VALUES (@ContractNumber, @UserId, @ContractData, @ContractStartData, @ContractEndData, @Insurance, @TotalPrice, @PaymentMethod);

            SELECT CAST(SCOPE_IDENTITY() AS INT);";
        return await db.ExecuteScalarAsync<int>(sql, number);
    }

    public async Task<IEnumerable<Contracts>> GetAllAsync()
    {
        using var db = CreateConnection();

        string sql = @"
            SELECT * FROM Contracts
            ";
        return await db.QueryAsync<Contracts>(sql);
    }
}
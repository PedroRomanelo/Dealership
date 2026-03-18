using Dapper;
using Dealership.Model.Entities;
using Dealership.Repository.Interfaces;

namespace Dealership.Repository.Implementations;

public class ContractRepository : BaseRepository, IContractRepository
{
    public ContractRepository(string connectionString) : base(connectionString) { }

    public async Task<int> InsertAsync(Contracts contract)
    {
        using var db = CreateConnection();

        string sql = @"
            INSERT INTO Contracts 
            (
                ContractNumber,
                UserId,
                VehicleId,
                ContractDate,
                ContractStartDate,
                ContractEndDate,
                InsuranceId,
                TotalPrice,
                PaymentMethodId
            )
            VALUES 
            (
                @ContractNumber,
                @UserId,
                @VehicleId,
                @ContractDate,
                @ContractStartDate,
                @ContractEndDate,
                @InsuranceId,
                @TotalPrice,
                @PaymentMethodId
            );

            SELECT CAST(SCOPE_IDENTITY() AS INT);
        ";

        return await db.ExecuteScalarAsync<int>(sql, contract);
    }
}
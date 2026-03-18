using Dapper;
using Dealership.Model.Response.Report;
using Dealership.Repository.Interfaces;

namespace Dealership.Repository.Implementations;

public class ReportRepository(string connectionString) : BaseRepository(connectionString), IReportRepository
{
    public async Task<IEnumerable<MonthlyContractReportVM>> GetContractsByMonthAsync(int year)
    {
        using var db = CreateConnection();
        string sql = @"
            SELECT MONTH(ContractStartDate) as Month, COUNT(Id) as TotalContracts, SUM(TotalPrice) as TotalPrice
            FROM Contracts
            WHERE YEAR(ContractStartDate) = @Year
            GROUP BY MONTH(ContractStartDate)";
        return await db.QueryAsync<MonthlyContractReportVM>(sql, new { Year = year });
    }

    public async Task<IEnumerable<BrandMonthlyReportVM>> GetContractsByMonthAndBrandAsync(int year)
    {
        using var db = CreateConnection();
        string sql = @"
            SELECT Models.Brand as Brand, MONTH(Contracts.ContractStartDate) as Month, COUNT(Contracts.Id) as TotalContracts, SUM(Contracts.TotalPrice) as TotalPrice
            FROM Contracts
            JOIN Vehicles ON Contracts.VehicleId = Vehicles.Id
            JOIN Models ON Vehicles.ModelId = Models.Id
            WHERE YEAR(Contracts.ContractStartDate) = @Year
            GROUP BY Models.Brand, MONTH(Contracts.ContractStartDate)";
        return await db.QueryAsync<BrandMonthlyReportVM>(sql, new { Year = year });
    }

    public async Task<IEnumerable<CustomerSpendingVM>> GetCustomersTotalSpentAsync()
    {
        using var db = CreateConnection();
        string sql = @"
            SELECT Users.Name as CustomerName, SUM(Contracts.TotalPrice) as TotalSpent
            FROM Users
            JOIN Contracts ON Users.Id = Contracts.UserId
            GROUP BY Users.Name
            ORDER BY TotalSpent DESC";
        return await db.QueryAsync<CustomerSpendingVM>(sql);
    }

    public async Task<IEnumerable<ActiveContractTimeVM>> GetActiveContractsWithRemainingTimeAsync()
    {
        using var db = CreateConnection();
        string sql = @"
            SELECT Contracts.Id as ContractId, Users.Name as CustomerName, Vehicles.LicensePlate,
            CAST(DATEDIFF(HOUR, GETDATE(), Contracts.ContractEndDate) / 24 AS VARCHAR) + ' dias e ' + 
            CAST(DATEDIFF(HOUR, GETDATE(), Contracts.ContractEndDate) % 24 AS VARCHAR) + ' horas' as RemainingTime
            FROM Contracts
            JOIN Users ON Contracts.UserId = Users.Id
            JOIN Vehicles ON Contracts.VehicleId = Vehicles.Id
            WHERE GETDATE() BETWEEN Contracts.ContractStartDate AND Contracts.ContractEndDate";
        return await db.QueryAsync<ActiveContractTimeVM>(sql);
    }

    public async Task<IEnumerable<PaymentMethodMonthlyReportVM>> GetContractsByMonthAndPaymentMethodAsync(int year)
    {
        using var db = CreateConnection();
        string sql = @"
            SELECT 
                PM.Name as PaymentMethod, 
                MONTH(Contracts.ContractStartDate) as Month, 
                COUNT(Contracts.Id) as TotalContracts, 
                SUM(Contracts.TotalPrice) as TotalPrice
            FROM Contracts
            JOIN PaymentMethod PM ON Contracts.PaymentMethodId = PM.Id
            WHERE YEAR(Contracts.ContractStartDate) = @Year
            GROUP BY PM.Name, MONTH(Contracts.ContractStartDate)";

        return await db.QueryAsync<PaymentMethodMonthlyReportVM>(sql, new { Year = year });
    }
}
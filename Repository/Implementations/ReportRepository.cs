using Dapper;
using Dealership.Model.Response.Report;
using Dealership.Repository.Interfaces;

namespace Dealership.Repository.Implementations;

public class ReportRepository(string connectionString) : BaseRepository(connectionString), IReportRepository
{
    public async Task<IEnumerable<MonthlyRentalReportVM>> GetRentalsByMonthAsync(int year)
    {
        using var db = CreateConnection();
        string sql = @"
            SELECT MONTH(StartDate) as Month, COUNT(Id) as TotalRentals, SUM(TotalValue) as TotalValue
            FROM Rentals
            WHERE YEAR(StartDate) = @Year
            GROUP BY MONTH(StartDate)";
        return await db.QueryAsync<MonthlyRentalReportVM>(sql, new { Year = year });
    }

    public async Task<IEnumerable<BrandMonthlyReportVM>> GetRentalsByMonthAndBrandAsync(int year)
    {
        using var db = CreateConnection();
        string sql = @"
            SELECT B.Name as Brand, MONTH(R.StartDate) as Month, COUNT(R.Id) as TotalRentals, SUM(R.TotalValue) as TotalValue
            FROM Rentals R
            JOIN Vehicles V ON R.VehicleId = V.Id
            JOIN Models M ON V.ModelId = M.Id
            JOIN Brands B ON M.BrandId = B.Id
            WHERE YEAR(R.StartDate) = @Year
            GROUP BY B.Name, MONTH(R.StartDate)";
        return await db.QueryAsync<BrandMonthlyReportVM>(sql, new { Year = year });
    }

    public async Task<IEnumerable<CustomerSpendingVM>> GetCustomersTotalSpentAsync()
    {
        using var db = CreateConnection();
        string sql = @"
            SELECT U.Name as CustomerName, SUM(R.TotalValue) as TotalSpent
            FROM Users U
            JOIN Rentals R ON U.Id = R.UserId
            GROUP BY U.Name
            ORDER BY TotalSpent DESC";
        return await db.QueryAsync<CustomerSpendingVM>(sql);
    }

    public async Task<IEnumerable<ActiveContractTimeVM>> GetActiveContractsWithRemainingTimeAsync()
    {
        using var db = CreateConnection();
        string sql = @"
            SELECT R.Id as ContractId, U.Name as CustomerName, V.LicensePlate,
            CAST(DATEDIFF(HOUR, GETDATE(), R.EndDate) / 24 AS VARCHAR) + ' dias e ' + 
            CAST(DATEDIFF(HOUR, GETDATE(), R.EndDate) % 24 AS VARCHAR) + ' horas' as RemainingTime
            FROM Rentals R
            JOIN Users U ON R.UserId = U.Id
            JOIN Vehicles V ON R.VehicleId = V.Id
            WHERE R.EndDate > GETDATE() AND R.Status = 1";
        return await db.QueryAsync<ActiveContractTimeVM>(sql);
    }

    public async Task<IEnumerable<PaymentMethodMonthlyReportVM>> GetRentalsByMonthAndPaymentMethodAsync(int year)
    {
        using var db = CreateConnection();
        string sql = @"
            SELECT 
                PM.Name as PaymentMethod, 
                MONTH(R.StartDate) as Month, 
                COUNT(R.Id) as TotalRentals, 
                SUM(R.TotalValue) as TotalValue
            FROM Rentals R
            JOIN PaymentMethod PM ON R.PaymentMethodId = PM.Id
            WHERE YEAR(R.StartDate) = @Year
            GROUP BY PM.Name, MONTH(R.StartDate)";

        return await db.QueryAsync<PaymentMethodMonthlyReportVM>(sql, new { Year = year });
    }
}
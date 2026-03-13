using Dealership.Model.Entities;

namespace Dealership.Repository.Interfaces;

public interface IReportRepository
{
    Task<bool> GetRentalsByMonthAsync(int year);
    Task<bool> GetRentalsByMonthAndBrandAsync(int year);
    Task<bool> GetRentalsByMonthAndPaymentMethodAsync(int year);
    Task<bool> GetCustomersTotalSpentAsync();
    Task<bool> GetActiveContractsWithRemainingTimeAsync();
}
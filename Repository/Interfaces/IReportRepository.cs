using Dealership.Model.Response.Report;

namespace Dealership.Repository.Interfaces;

public interface IReportRepository
{
    Task<IEnumerable<MonthlyRentalReportVM>> GetRentalsByMonthAsync(int year);
    Task<IEnumerable<BrandMonthlyReportVM>> GetRentalsByMonthAndBrandAsync(int year);
    Task<IEnumerable<PaymentMethodMonthlyReportVM>> GetRentalsByMonthAndPaymentMethodAsync(int year);
    Task<IEnumerable<CustomerSpendingVM>> GetCustomersTotalSpentAsync();
    Task<IEnumerable<ActiveContractTimeVM>> GetActiveContractsWithRemainingTimeAsync();
}
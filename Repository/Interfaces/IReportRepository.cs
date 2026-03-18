using Dealership.Model.Response.Report;

namespace Dealership.Repository.Interfaces;

public interface IReportRepository
{
    Task<IEnumerable<MonthlyContractReportVM>> GetContractsByMonthAsync(int year);
    Task<IEnumerable<BrandMonthlyReportVM>> GetContractsByMonthAndBrandAsync(int year);
    Task<IEnumerable<PaymentMethodMonthlyReportVM>> GetContractsByMonthAndPaymentMethodAsync(int year);
    Task<IEnumerable<CustomerSpendingVM>> GetCustomersTotalSpentAsync();
    Task<IEnumerable<ActiveContractTimeVM>> GetActiveContractsWithRemainingTimeAsync();
}
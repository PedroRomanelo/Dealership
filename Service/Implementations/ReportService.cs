using Dealership.Model.Response.Report;
using Dealership.Repository.Interfaces;
using Dealership.Service.Interfaces;

namespace Dealership.Service.Implementations;

public class ReportService(IReportRepository reportRepository) : IReportService
{
    public async Task<IEnumerable<MonthlyContractReportVM>> GetContractsByMonthAsync(int year) =>
        await reportRepository.GetContractsByMonthAsync(year);

    public async Task<IEnumerable<BrandMonthlyReportVM>> GetContractsByMonthAndBrandAsync(int year) =>
        await reportRepository.GetContractsByMonthAndBrandAsync(year);

    public async Task<IEnumerable<PaymentMethodMonthlyReportVM>> GetContractsByMonthAndPaymentMethodAsync(int year) =>
        await reportRepository.GetContractsByMonthAndPaymentMethodAsync(year);

    public async Task<IEnumerable<CustomerSpendingVM>> GetCustomersTotalSpentAsync() =>
        await reportRepository.GetCustomersTotalSpentAsync();

    public async Task<IEnumerable<ActiveContractTimeVM>> GetActiveContractsWithRemainingTimeAsync() =>
        await reportRepository.GetActiveContractsWithRemainingTimeAsync();
}
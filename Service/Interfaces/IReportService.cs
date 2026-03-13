namespace Dealership.Service.Interfaces;
public interface ReportService
{
    Task() GetRentalsByMonthAsync(int year);
    Task() GetRentalsByMonthAndBrandAsync(int year);
    Task() GetRentalsByMonthAndPaymentMethodAsync(int year);
    Task() GetCustomersTotalSpentAsync();
    Task() GetActiveContractsWithRemainingTimeAsync();
}

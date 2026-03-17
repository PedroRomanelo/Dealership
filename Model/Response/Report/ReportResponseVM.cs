namespace Dealership.Model.Response.Report;

public class MonthlyRentalReportVM
{
    public int Month { get; set; }
    public int TotalRentals { get; set; }
    public decimal TotalValue { get; set; }
}

public class BrandMonthlyReportVM : MonthlyRentalReportVM
{
    public string Brand { get; set; } = string.Empty;
}

public class PaymentMethodMonthlyReportVM : MonthlyRentalReportVM
{
    public string PaymentMethod { get; set; } = string.Empty;
}

public class CustomerSpendingVM
{
    public string CustomerName { get; set; } = string.Empty;
    public decimal TotalSpent { get; set; }
}

public class ActiveContractTimeVM
{
    public int ContractId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string LicensePlate { get; set; } = string.Empty;
    public string RemainingTime { get; set; } = string.Empty; // Ex: "2 dias e 4 horas"
}
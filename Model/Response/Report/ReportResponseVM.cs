namespace Dealership.Model.Response.Report;

public class MonthlyContractReportVM
{
    public int? Month { get; set; }
    public int? TotalContracts { get; set; }
    public decimal? TotalPrice { get; set; }
}

public class BrandMonthlyReportVM : MonthlyContractReportVM
{
    public string? Brand { get; set; }
}

public class PaymentMethodMonthlyReportVM : MonthlyContractReportVM
{
    public string? PaymentMethod { get; set; }
}

public class CustomerSpendingVM
{
    public string? CustomerName { get; set; }
    public decimal? TotalSpent { get; set; }
}

public class ActiveContractTimeVM
{
    public int? ContractId { get; set; }
    public string? CustomerName { get; set; }
    public string? LicensePlate { get; set; }
    public string? RemainingTime { get; set; }
}
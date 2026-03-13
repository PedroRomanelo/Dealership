namespace Dealership.Model.Request.Contract;

public class ContractCreateVM
{
    public string ContractNumber { get; set; } = string.Empty;
    public int UserId { get; set; }
    public DateTime ContractStartData { get; set; }
    public DateTime ContractEndData { get; set; }
    public int InsuranceId { get; set; }
    public decimal TotalPrice { get; set; }
    public int PaymentMethodId { get; set; }
    public int VehicleId { get; set; }
}
namespace Dealership.Model.Request.Contract;

public class ContractRequestVM
{
    public required int UserId { get; set; }
    public required DateTime ContractStartDate { get; set; }
    public required DateTime ContractEndDate { get; set; }
    public int? InsuranceId { get; set; }
    public required int PaymentMethodId { get; set; }
    public required int VehicleId { get; set; }
}
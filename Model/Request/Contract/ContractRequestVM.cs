namespace Dealership.Model.Request.Contract;

public class ContractRequestVM
{
    public int UserId { get; set; }
    public DateTime ContractStartDate { get; set; }
    public DateTime ContractEndDate { get; set; }
    public int InsuranceId { get; set; } //ou bool para insuranceExist
    public int PaymentMethodId { get; set; }
    public int VehicleId { get; set; }
}
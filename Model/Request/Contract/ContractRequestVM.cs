namespace Dealership.Model.Request.Rental;

public class ContractRequestVM
{
    public int UserId { get; set; }
    public int VehicleId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool UseInsurance { get; set; }
    public int PaymentMethodId { get; set; }
}
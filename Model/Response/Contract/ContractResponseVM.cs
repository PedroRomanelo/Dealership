namespace Dealership.Model.Response.Rental;

public class ContractSimulationVM
{
    public string CustomerName { get; set; } = string.Empty;
    public string VehiclePlate { get; set; } = string.Empty;
    public string PaymentMethod { get; set; } = string.Empty;
    public int TotalDays { get; set; }
    public decimal VehicleCost { get; set; }
    public decimal InsuranceCost { get; set; }
    public decimal GrandTotal { get; set; }
}
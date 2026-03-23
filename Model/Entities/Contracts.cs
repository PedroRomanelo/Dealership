namespace Dealership.Model.Entities;
public class Contracts
{
    public int Id { get; set; }
    public required string ContractNumber { get; set; }
    public required int UserId { get; set; }
    public required DateTime ContractDate {  get; set; }
    public required DateTime ContractStartDate { get; set; }
    public required DateTime ContractEndDate { get; set; } 
    public int? InsuranceId { get; set; }
    public decimal TotalPrice { get; set; }
    public required int PaymentMethodId { get; set; }
    public required int VehicleId { get; set; }
}

namespace Dealership.Model.Entities;
public class Contracts
{
    public int Id { get; set; }
    public string ContractNumber { get; set; }
    public int UserId { get; set; }
    public DateTime ContractDate {  get; set; }
    public DateTime ContractStartDate { get; set; }
    public DateTime ContractEndDate{ get; set; } 
    public int? InsuranceId { get; set; }
    public decimal TotalPrice { get; set; }
    public int PaymentMethodId { get; set; }
    public int VehicleId { get; set; }
}

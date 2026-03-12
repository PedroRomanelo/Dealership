namespace Dealership.Model.Entities;
public class Contracts
{
    public int Id { get; set; }
    public string ContractNumber { get; set; }
    public int UserId { get; set; }
    public DateTime ContractData {  get; set; }
    public DateTime ContractStartData { get; set; }
    public DateTime ContractEndData { get; set; } 
    public int Insurance { get; set; }
    public decimal TotalPrice { get; set; }
    public int PaymentMethod { get; set; }
}

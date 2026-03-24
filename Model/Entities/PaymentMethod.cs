namespace Dealership.Model.Entities;

public class PaymentMethod
{
    public int Id { get; set; }
    public string? Description { get; set; }
    public bool? Status { get; set; }
    public required string Name { get; set; }
}
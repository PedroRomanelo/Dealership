namespace Dealership.Model.Request.PaymentMethod;

public class PaymentMethodCreateVM
{
    public string? Description { get; set; }
    public required string Name { get; set; }
}
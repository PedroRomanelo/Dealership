namespace Dealership.Model.Entities;

public class Models
{
    public int Id { get; set; }
    public required string Model { get; set; }
    public required string Brand { get; set; }
    public bool? Status { get; set; }
}

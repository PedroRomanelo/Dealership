namespace Dealership.Model.Entities;

public class Vehicles
{
    public int Id { get; set; }
    public required string LicensePlate { get; set; }
    public required int ModelId { get; set; }
    public required decimal Mileage { get; set; }
    public required decimal DailyRate { get; set; }
}

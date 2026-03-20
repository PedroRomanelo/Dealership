namespace Dealership.Model.Entities;

public class Vehicles
{
    public int Id { get; set; }
    public string LicensePlate { get; set; }
    public int ModelId { get; set; }
    public decimal Mileage { get; set; }
    public decimal DailyRate { get; set; }
}

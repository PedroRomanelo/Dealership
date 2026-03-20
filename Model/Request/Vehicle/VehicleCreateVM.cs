namespace Dealership.Model.Request.Vehicle;

public class VehicleCreateVM
{
    public required string LicensePlate { get; set; }
    public required int ModelId { get; set; }
    public required decimal Mileage { get; set; }
    public required decimal DailyRate { get; set; }
}
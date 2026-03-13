namespace Dealership.Model.Request.Vehicle;

public class VehicleCreateVM
{
    public string LicensePlate { get; set; }
    public int ModelId { get; set; }
    public decimal Mileage { get; set; }
    public decimal DailyRate { get; set; }
}
namespace Dealership.Model.Request.Insurance;

public class InsuranceCreateVM
{
    public string? Description { get; set; }
    public required int ModelId { get; set; }
    public required decimal DailyRate { get; set; }
}
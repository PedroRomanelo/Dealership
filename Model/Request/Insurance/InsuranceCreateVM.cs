namespace Dealership.Model.Request.Insurance;

public class InsuranceCreateVM
{
    public string Description { get; set; } = string.Empty;
    public int ModelId { get; set; }
    public decimal DailyRate { get; set; }
}
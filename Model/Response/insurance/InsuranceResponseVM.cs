namespace Dealership.Model.Response.insurance;

public class InsuranceResponseVM
{
    public string Description { get; set; } = string.Empty;
    public int ModelId { get; set; }
    public decimal DailyRate { get; set; }
}
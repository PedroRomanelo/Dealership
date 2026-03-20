namespace Dealership.Model.Request.Insurance;

public class InsuranceUpdateVM
{
    public string? Description { get; set; }
    public int? ModelId { get; set; }
    public decimal? DailyRate { get; set; }
}
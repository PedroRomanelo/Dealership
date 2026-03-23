namespace Dealership.Model.Entities;

public class Insurance
{
    public int Id {  get; set; }
    public string? Description { get; set; }
    public required int ModelId { get; set; }
    public required decimal DailyRate { get; set; }
}

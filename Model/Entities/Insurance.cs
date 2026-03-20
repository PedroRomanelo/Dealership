namespace Dealership.Model.Entities;

public class Insurance
{
    public int Id {  get; set; }
    public string Description { get; set; }
    public int ModelId { get; set; }
    public decimal DailyRate { get; set; }
}

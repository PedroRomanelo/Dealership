namespace Dealership.Model.Entities;
public class Users
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Document { get; set; }
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? BirthDate { get; set; }
    public bool Status { get; set; }
}

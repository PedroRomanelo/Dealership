namespace Dealership.Model.Request.User;

public class UserRegisterVM
{
    public required string Name { get; set; }
    public required string Document {  get; set; }
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? BirthDate { get; set; }
}

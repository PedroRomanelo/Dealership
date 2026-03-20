namespace Dealership.Model.Request.User;

public class UserUpdateVM
{
    public string? Name { get; set; }
    public string? Document { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? BirthDate { get; set; }
}

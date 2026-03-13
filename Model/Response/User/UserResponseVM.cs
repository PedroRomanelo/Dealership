namespace Dealership.Model.Response.User;

public class UserResponseVM
{
    public string Name { get; set; }
    public string Document { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateOnly BirthDate { get; set; }
}

namespace Dealership.Model.Entities;
public class Users
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Document { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public DateOnly BirthDate { get; set; }
    public bool Status { get; set; }
}

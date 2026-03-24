namespace Dealership.Model.Entities;
public class AdminUsers
{
    public int Id { get; set; }
    public required string Login { get; set; }
    public required string Password { get; set; }
    public string? Role { get; set; }
}
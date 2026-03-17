
namespace Dealership.Model.Entities;
public class UserAddresses
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string State { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public bool Status { get; set; }
}

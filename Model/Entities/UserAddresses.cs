
namespace Dealership.Model.Entities;
public class UserAddresses
{
    public int Id { get; set; }
    public required int UserId { get; set; }
    public required string State { get; set; }
    public required string City { get; set; }
    public required string Street { get; set; }
    public required string Number { get; set; }
    public bool Status { get; set; }
}

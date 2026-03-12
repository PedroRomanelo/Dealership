
namespace Dealership.Model.Entities;
public class UserAddress
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public int Number { get; set; }
    public bool Status { get; set; }
}

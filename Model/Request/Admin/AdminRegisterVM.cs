using Dealership.Model.Enums;

namespace Dealership.Model.Request.Admin;
    public class AdminRegisterVM
    {
    public required string Login { get; set; }
    public required string Password { get; set; }
    public required RolesEnum Roles { get; set; }
}

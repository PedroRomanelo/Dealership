using Dealership.Model.Enums;

namespace Dealership.Model.Request.Admin;
    public class RegisterAdminVM
    {
    public string Login { get; set; }
    public string Password { get; set; }
    public RolesEnum Roles { get; set; }
}

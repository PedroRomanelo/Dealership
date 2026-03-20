namespace Dealership.Model.Request.Admin;

public class AdminResetPasswordRequestVM
{
    public required string Login { get; set; }
    public required string Token { get; set; }//enviado por e-mail
    public required string NewPassword { get; set; }
}

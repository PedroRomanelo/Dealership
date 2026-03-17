namespace Dealership.Model.Request.Admin;

public class ResetPasswordRequestVM
{
    public string Login { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;//enviado por e-mail
    public string NewPassword { get; set; } = string.Empty;
}

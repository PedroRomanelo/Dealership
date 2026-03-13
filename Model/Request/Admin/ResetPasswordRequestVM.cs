namespace Dealership.Model.Request.Admin;

public class ResetPasswordRequestVM
{
    public string Email { get; set; }
    public string Token { get; set; }//enviado por e-mail
    public string NewPassword { get; set; }
}

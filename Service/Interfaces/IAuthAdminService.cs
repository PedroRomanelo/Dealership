using Dealership.Model.Request.Admin;
using Dealership.Model.Response.Admin;

namespace Dealership.Service.Interfaces;

public interface IAuthAdminService
{
    Task<AdminResponseVM> RegisterAsync(AdminRegisterVM request); //retorna strg pq será o token
    Task<AdminResponseVM> LoginAsync(AdminLoginVM request); //vide
    Task<bool> ForgotPasswordAsync(AdminForgotPasswordRequestVM request);
    Task<bool> ResetPasswordAsync(AdminResetPasswordRequestVM request);
}
 
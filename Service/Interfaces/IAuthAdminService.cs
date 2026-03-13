using Microsoft.AspNetCore.Identity.Data;
using Dealership.Model.Request.Admin;

namespace Dealership.Service.Interfaces;

public interface IAuthAdminService
{
    Task<string> RegisterAsync(RegisterAdminVM request); //retorna strg pq será o token
    Task<string> LoginAsync(LoginAdminVM request); //vide
    Task<bool> ForgotPasswordAsync(ForgotPasswordRequestVM request);
    Task<bool> ResetPasswordAsync(ResetPasswordRequestVM request);
}

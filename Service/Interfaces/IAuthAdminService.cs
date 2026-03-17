using Dealership.Model.Request.Admin;
using Dealership.Model.Response.Admin;
using Microsoft.AspNetCore.Identity.Data;

namespace Dealership.Service.Interfaces;

public interface IAuthAdminService
{
    Task<AdminResponseVM> RegisterAsync(RegisterAdminVM request); //retorna strg pq será o token
    Task<AdminResponseVM> LoginAsync(LoginAdminVM request); //vide
    Task<bool> ForgotPasswordAsync(ForgotPasswordRequestVM request);
    Task<bool> ResetPasswordAsync(ResetPasswordRequestVM request);
}

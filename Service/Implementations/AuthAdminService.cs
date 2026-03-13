using Dealership.Model.Entities;
using Dealership.Model.Request.Admin;
using Dealership.Repository.Interfaces;
using Dealership.Service.Interfaces;
using Microsoft.AspNetCore.Identity.Data;
using Dealership.Model.Response.Admin;

namespace Dealership.Service.Implementations;

public class AuthService
{
    private readonly IEmailService _emailService;
    private readonly ITokenService _tokenService;
    private readonly IPasswordRecoveryTokenService _passwordRecoveryTokenService;
    private readonly IAdminUserRepository _adminUserRepository;

    public AuthService
        (IEmailService emailService,
        ITokenService tokenService,
        IPasswordRecoveryTokenService passwordRecoveryTokenService,
        IAdminUserRepository adminUserRepository)
    {
        _emailService = emailService;
        _tokenService = tokenService;
        _passwordRecoveryTokenService = passwordRecoveryTokenService;
        _adminUserRepository = adminUserRepository;
    }

    public async Task<AdminResponseVM> RegisterAsync(RegisterAdminVM request) 
    {
        var UserExist = await _adminUserRepository.GetByLoginAsync(request.Login);
        if(UserExist != null)
        {
            throw new Exception("Login já cadastrado");
        }

        string hash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var newAdmin = new AdminUsers
        {
            Login = request.Login,
            Password = hash,
            Role = "admin"
        };

        int adminId = await _adminUserRepository.CreateAsync(newAdmin);
        newAdmin.Id = adminId;

        string tokenJwt = _tokenService.GenerateToken(newAdmin);

        return new AdminResponseVM
        {
            Token = tokenJwt,
        };
    }
    public async Task<bool> LoginAsync(LoginAdminVM request) { }
    public async Task<bool> ForgotPasswordAsync(ForgotPasswordRequestVM request) { }
    public async Task<bool> ResetPasswordAsync(ResetPasswordRequestVM request) { }
}

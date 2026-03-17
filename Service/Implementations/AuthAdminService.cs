using Dealership.Model.Entities;
using Dealership.Model.Request.Admin;
using Dealership.Repository.Interfaces;
using Dealership.Service.Interfaces;
using Microsoft.AspNetCore.Identity.Data;
using Dealership.Model.Response.Admin;
using BCrypt.Net;

namespace Dealership.Service.Implementations;

public class AuthService : IAuthAdminService
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
        var userExist = await _adminUserRepository.GetByLoginAsync(request.Login);

        if (userExist != null)
        {
            throw new Exception("Login já cadastrado");
        }

        string hash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var newAdmin = new AdminUsers
        {
            Login = request.Login,
            Password = hash,
            Role = request.Roles.ToString()
        };

        int adminId = await _adminUserRepository.CreateAsync(newAdmin);
        newAdmin.Id = adminId;

        string tokenJwt = _tokenService.GenerateToken(newAdmin);

        return new AdminResponseVM
        {
            Token = tokenJwt,
        };
    }
    public async Task<AdminResponseVM> LoginAsync(LoginAdminVM request)
    {
        var user = await _adminUserRepository.GetByLoginAsync(request.Login);

        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        {
            throw new Exception("Login ou senha inválidos");
        }

        string token = _tokenService.GenerateToken(user);

        return new AdminResponseVM
        {
            Token = token
        };
    }
    public async Task<bool> ForgotPasswordAsync(ForgotPasswordRequestVM request)
    {
        var user = await _adminUserRepository.GetByLoginAsync(request.Login);

        if (user == null)
        {
            return true; //
        }

        string recoveryToken = _passwordRecoveryTokenService.GenerateRecoveryToken(user);

        await _emailService.SendRecoveryEmailAsync(request.Login, recoveryToken);

        return true;
    }
    public async Task<bool> ResetPasswordAsync(ResetPasswordRequestVM request)
    {
        var user = await _adminUserRepository.GetByLoginAsync(request.Login);

        if (user == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        // Validação do token
        bool isTokenValid = _passwordRecoveryTokenService.ValidateRecoveryToken(request.Token);
        if (!isTokenValid)
        {
            throw new Exception("Token inválido ou expirado.");
        }

        string novoHash = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);

        await _adminUserRepository.UpdatePasswordAsync(user.Id, novoHash);

        return true;
    }
}

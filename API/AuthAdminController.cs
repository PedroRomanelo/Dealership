using Microsoft.AspNetCore.Mvc;
using Dealership.Model.Request.Admin;
using Dealership.Service.Interfaces;

namespace Dealership.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthAdminController : ControllerBase
{
    private readonly IAuthAdminService _authAdminService;

    public AuthAdminController(IAuthAdminService authAdminService)
    {
        _authAdminService = authAdminService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterAdminVM request)
    {
        try
        {
            var response = await _authAdminService.RegisterAsync(request);
            return Ok(response); // Retorna 200 com o token JWT
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message }); // Retorna 400 se o usuário já existir
        }
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginAdminVM request)
    {
        try
        {
            var response = await _authAdminService.LoginAsync(request);
            return Ok(response); // Retorna 200 com o token JWT
        }
        catch (Exception ex)
        {
            return Unauthorized(new { message = ex.Message }); // Retorna 401
        }
    }

    [HttpPost("forgot-password")]
    public async Task<IActionResult> ForgotPasswordAsync([FromBody] ForgotPasswordRequestVM request)
    {
        try
        {
            await _authAdminService.ForgotPasswordAsync(request);
            return Ok(new { message = "Se o e-mail existir em nossa base, as instruções de recuperação serão enviadas." }); 
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("reset-password")]
    public async Task<IActionResult> ResetPasswordAsync([FromBody] ResetPasswordRequestVM request)
    {
        try
        {
            await _authAdminService.ResetPasswordAsync(request);
            return Ok(new { message = "Senha alterada com sucesso." }); // 200
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message }); // 400
        }
    }
}
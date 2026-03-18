using Dealership.Model.Request.User;
using Dealership.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dealership.API;
 
[ApiController]
[Authorize]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("document/{document}")]
    public async Task<IActionResult> GetByDocumentAsync(string document)
    {
        var user = await _userService.GetByDocumentAsync(document);

        if( user == null)
        {
            return NotFound(new { message = "user não encontrado" });
        }
        return Ok(user);
    }

    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetByEmailAsync(string email)
    {
        var user = await _userService.GetByEmailAsync(email);

        if (user == null)
        {
            return NotFound(new { message = "user não encontrado" });
        }
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] UserRegisterVM request)
    {
        try
        {
            var response = await _userService.CreateAsync(request);
            return Created(string.Empty, response); //201
        }
        catch (Exception ex)
        {
            return BadRequest( new {message = ex.Message}); //400
        }
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] UserUpdateVM request)
    {
        try
        {
            var response = await _userService.UpdateAsync(id, request);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {message = ex.Message});
        }
    }

    [HttpPatch("{id}/deactivate")]
    public async Task<IActionResult> DeactivateAsync(int id)
    {
        try
        {
            await _userService.DeactivateAsync(id);
            return NoContent(); //204
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}

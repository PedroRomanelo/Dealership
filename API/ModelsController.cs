using Dealership.Model.Request.Model;
using Dealership.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dealership.API;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ModelsController : ControllerBase
{
    private readonly IModelsService _modelsService;

    public ModelsController ( IModelsService modelsService)
    {
        _modelsService = modelsService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] ModelRegisterVM request)
    {
        var model = await _modelsService.CreateAsync(request);
        return Created (string.Empty, model);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] ModelUpdateVM request)
    {
        try
        {
            var model = await _modelsService.UpdateAsync(id, request);
            return Ok(model);
        }
        catch(Exception ex)
        {
            return BadRequest(new {message = ex.Message});
        }
    }

    [HttpPatch("deactivate/{id}")]
    public async Task<IActionResult> DeactivateAsync(int id) 
    {
        var success = await _modelsService.DeactivateAsync(id);

        if(!success)
        {
            return BadRequest(new { message = "a inativação do modelo falhou tente novamente" });
        }

        return NoContent();
    }

    [HttpGet("name/{modelName}")]
    public async Task<IActionResult> GetByModelAsync(string modelName)
    {
        var response = await _modelsService.GetByModelAsync(modelName);

        if (!response.Any())
            return NotFound(new { message = "Nenhum modelo encontrado." });

        return Ok(response);
    }

    [HttpGet("brand/{brand}")]
    public async Task<IActionResult> GetByBrandAsync(string brand)
    {
        var response = await _modelsService.GetByBrandAsync(brand);

        if (!response.Any())
            return NotFound(new { message = "Nenhum modelo encontrado." });

        return Ok(response);
    }
}

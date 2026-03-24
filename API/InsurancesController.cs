using Microsoft.AspNetCore.Mvc;
using Dealership.Model.Request.Insurance;
using Dealership.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Dealership.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InsuranceController : ControllerBase
{
    private readonly IInsuranceService _insuranceService;

    public InsuranceController(IInsuranceService insuranceService)
    {
        _insuranceService = insuranceService;
    }

    [Authorize(Roles = "admin,financial")]
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] InsuranceCreateVM request)
    {
        var id = await _insuranceService.CreateAsync(request);
        return CreatedAtRoute("GetModelByModelId", new { modelId = request.ModelId}, new { id });
    } 

    [Authorize(Roles = "admin,financial")]
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] InsuranceUpdateVM request)
    {
        var success = await _insuranceService.UpdateAsync(id, request);
        if (!success) return NotFound(new { message = "Seguro não localizado." });
        return Ok(new { message = "Seguro atualizado !!" });
    }

    [Authorize]
    [HttpGet("model/{modelId}", Name = "GetModelByModelId")]
    public async Task<IActionResult> GetByModelIdAsync(int modelId)
    {
        var result = await _insuranceService.GetByModelIdAsync(modelId);
        return Ok(result);
    }
}
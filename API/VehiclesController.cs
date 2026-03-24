using Microsoft.AspNetCore.Mvc;
using Dealership.Model.Request.Vehicle;
using Dealership.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Dealership.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class VehicleController : ControllerBase
{
    private readonly IVehicleService _vehicleService;

    public VehicleController(IVehicleService vehicleService)
    {
        _vehicleService = vehicleService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] VehicleCreateVM request)
    {
        var id = await _vehicleService.CreateAsync(request);
        return CreatedAtRoute("GetVehicleByPlate", new { plate = request.LicensePlate }, new {id});

        //lançar 409
    }
    
    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] VehicleUpdateVM request)
    {
        var success = await _vehicleService.UpdateAsync(id, request);
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpGet("plate/{plate}", Name = "GetVehicleByPlate")]
    public async Task<IActionResult> GetByPlateAsync(string plate)
    {
        var result = await _vehicleService.GetByPlateAsync(plate);
        return Ok(result);
    }

    [HttpGet("model/{modelId}")]
    public async Task<IActionResult> GetByModelIdAsync(int modelId)
    {
        var result = await _vehicleService.GetByModelIdAsync(modelId);
        return Ok(result);
    }

    [HttpPatch("deactivate/{id}")]
    public async Task<IActionResult> DeactivateAsync(int id)
    {
        await _vehicleService.DeactivateAsync(id);
        return NoContent();
    }
}
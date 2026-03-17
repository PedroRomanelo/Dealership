using Dealership.Model.Request.Address;
using Dealership.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dealership.API;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class AddressController : ControllerBase
{
    private readonly IAddressService _addressService;

    public AddressController( IAddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] AddressCreateRequest request)
    {
        var id = await _addressService.CreateAsync(request);

        return Created(string.Empty, new { id });
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] AddressUpdateRequest request)
    {
        var success = await _addressService.UpdateAsync(id, request);

        if(!success)
        {
            return BadRequest(new { message = "Ocorreu uma falha ao tentar atualizar" });
        }

        return Ok(new { message = "Endereço atualizado com sucesso" });
    }

    [HttpPatch("deactivate/{userId}")]
    public async Task<IActionResult> DeactivateByUserIdAsync(int userId)
    {
        var success = await _addressService.DeactivateByUserIdAsync(userId);

        if(!success)
        {
            return BadRequest(new { message = "Ocorreu uma falha, se reporte ao Serjinho para entender mais a respeito !" });
        }

        return NoContent();
    }
}

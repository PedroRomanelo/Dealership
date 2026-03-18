using Dealership.Model.Request.Contract;
using Dealership.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dealership.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/contracts")]
public class ContractController(IContractsService contractsService) : ControllerBase
{
    [HttpPost("preview")]
    public async Task<IActionResult> SimulateContract([FromBody] ContractRequestVM request)
    {
        try
        {
            var simulation = await contractsService.ViewContractAsync(request);
            return Ok(simulation);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateContract([FromBody] ContractRequestVM request)
    {
        try
        {
            var contractId = await contractsService.CreateContractAsync(request);
            // Retorna 201 Created apontando para o recurso gerado (caso tenha um endpoint de GET no futuro)
            return CreatedAtAction(nameof(CreateContract), new { id = contractId }, new { ContractId = contractId });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
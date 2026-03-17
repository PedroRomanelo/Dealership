using Microsoft.AspNetCore.Mvc;
using Dealership.Model.Request.contract;
using Dealership.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace Dealership.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class contractController : ControllerBase
{
    private readonly IContractService _contractService;

    public contractController(IContractService contractService)
    {
        _contractService = contractService;
    }

    // 4.7 - Apenas visualização/simulação (Não salva no banco)
    [HttpPost("simulate")]
    public async Task<IActionResult> SimulateAsync([FromBody] ContractRequestVM request)
    {
        var simulation = await _contractService.SimulateContractAsync(request);
        return Ok(simulation);
    }

    // 4.7.1 - Criação efetiva do contrato
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] ContractRequestVM request)
    {
        var contractId = await _contractService.CreateContractAsync(request);
        return Created(string.Empty, new { ContractId = contractId, Message = "Contrato gerado com sucesso." });
    }
}
using Dealership.Model.Request.PaymentMethod;
using Dealership.Service.Implementations;
using Dealership.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dealership.API;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PaymentMethodsController : ControllerBase
{
    private readonly IPaymentMethodService _paymentMethodService;
    public PaymentMethodsController(IPaymentMethodService paymentMethodService)
    {
        _paymentMethodService = paymentMethodService;
    }


    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] PaymentMethodCreateVM request)
    {
        var result = await _paymentMethodService.CreateAsync(request);
        return Created(string.Empty, result);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> UpdateAsync(int id, [FromBody] PaymentMethodUpdateVM request)
    {
        // O service decide o que atualizar baseado no que não for null
        var success = await _paymentMethodService.UpdateAsync(id, request);

        if (!success) return NotFound(new { message = "Meio de pagamento não encontrado." });

        return Ok(new { message = "Atualizado com sucesso." });
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _paymentMethodService.GetAllAsync());
    }

    [HttpPatch("deactivate/{id}")]
    public async Task<IActionResult> DeactivateAsync(int id)
    {
        await _paymentMethodService.DeactivateAsync(id);
        return NoContent();
    }
}

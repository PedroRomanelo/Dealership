using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Dealership.Service.Interfaces;
using Dealership.Model.Response.Report;

namespace Dealership.API.Controllers;

[ApiController]
[Route("reports")]
[Authorize(Roles = "admin,financeiro")]
public class ReportController(IReportService reportService) : ControllerBase
{
    [HttpGet("monthly-contracts")]
    public async Task<ActionResult<IEnumerable<MonthlyContractReportVM>>> GetContractsByMonth([FromQuery] int year)
    {
        var result = await reportService.GetContractsByMonthAsync(year);
        return Ok(result);
    }

    [HttpGet("monthly-contracts-by-brand")]
    public async Task<ActionResult<IEnumerable<BrandMonthlyReportVM>>> GetContractsByMonthAndBrand([FromQuery] int year)
    {
        var result = await reportService.GetContractsByMonthAndBrandAsync(year);
        return Ok(result);
    }

    [HttpGet("monthly-contracts-by-payment-method")]
    public async Task<ActionResult<IEnumerable<PaymentMethodMonthlyReportVM>>> GetContractsByMonthAndPaymentMethod([FromQuery] int year)
    {
        var result = await reportService.GetContractsByMonthAndPaymentMethodAsync(year);
        return Ok(result);
    }

    [HttpGet("customer-spending")]
    public async Task<ActionResult<IEnumerable<CustomerSpendingVM>>> GetCustomersTotalSpent()
    {
        var result = await reportService.GetCustomersTotalSpentAsync();
        return Ok(result);
    }

    [HttpGet("active-contracts-remaining-time")]
    public async Task<ActionResult<IEnumerable<ActiveContractTimeVM>>> GetActiveContractsWithRemainingTime()
    {
        var result = await reportService.GetActiveContractsWithRemainingTimeAsync();
        return Ok(result);
    }
}
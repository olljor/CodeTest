using CodeTest.Contracts.Requests;
using CodeTest.Contracts.Response;
using CodeTest.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeTest.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CustomerController(
        ILogger<OrderController> logger,
        CustomerService customerService) 
    : ControllerBase
{
    private readonly ILogger<OrderController> _logger = logger;
    private readonly CustomerService _customerService = customerService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerResponse>>> GetCustomers()
    {
        try
        {
            var result = await _customerService.GetCustomers();
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not get customers");
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddCustomer([FromBody] CustomerRequest request)
    {
        try
        {
            await _customerService.AddCustomer(request);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not add customer");
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("by-number/{number}")]
    public async Task<ActionResult> DeleteCustomerByNumber(int number)
    {
        try
        {
            await _customerService.DeleteCustomerByNumber(number);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not delete customer");
            return BadRequest(ex.Message);
        }
    }
}

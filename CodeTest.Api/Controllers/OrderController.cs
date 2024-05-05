using CodeTest.Contracts.Requests;
using CodeTest.Contracts.Response;
using CodeTest.Infrastructure.Entities;
using CodeTest.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeTest.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrderController(
        ILogger<OrderController> logger,
        OrderService orderService)
    : ControllerBase
{
    private readonly ILogger<OrderController> _logger = logger;
    private readonly OrderService _orderService = orderService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OrderResponse>>> GetOrders()
    {
        try
        {
            var result = await _orderService.GetOrders();
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not get Order");
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("by-id/{id}")]
    public async Task<ActionResult<OrderResponse>> GetOrderById(int id)
    {
        try
        {
            var result = await _orderService.GetOrderById(id);
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not get specific order");
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddOrder([FromBody] OrderRequest request)
    {
        try
        {
            await _orderService.AddOrder(request);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not add Order");
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("by-id/{id}")]
    public async Task<ActionResult> DeleteOrderById(int id)
    {
        try
        {
            await _orderService.DeleteOrderById(id);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not delete order");
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("rows")]
    public async Task<ActionResult<IEnumerable<OrderRowResponse>>> GetOrderRows()
    {
        try
        {
            var result = await _orderService.GetOrderRows();
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not get Order Rows");
            return BadRequest(ex.Message);
        }
    }

    //TODO: add api calls for orders
}

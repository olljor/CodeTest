using CodeTest.API.Controllers;
using CodeTest.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeTest.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SetupController(
        ILogger<SetupController> logger,
        SetupService setupService)
    : ControllerBase
{
    private readonly ILogger<SetupController> _logger = logger;
    private readonly SetupService _setupService = setupService;

    [HttpPost]
    public async Task<IActionResult> RunDatabaseSetupScript()
    {
        try
        {
            await _setupService.RunDatabaseSetupScript();
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not run setup script");
            return BadRequest("Could not run setup script");
        }
    }

}

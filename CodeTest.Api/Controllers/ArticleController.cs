using CodeTest.Contracts.Requests;
using CodeTest.Contracts.Response;
using CodeTest.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeTest.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ArticleController(
        ILogger<ArticleController> logger,
        ArticleService articleService)
    : ControllerBase
{
    private readonly ILogger<ArticleController> _logger = logger;
    private readonly ArticleService _articleService = articleService;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ArticleResponse>>> GetArticles()
    {
        try
        {
            var result = await _articleService.GetArticles();
            return Ok(result);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not get articles");
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult> AddArticle([FromBody] ArticleRequest request)
    {
        try
        {
            await _articleService.AddArticle(request);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not add article");
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("by-id/{id}")]
    public async Task<ActionResult> DeleteCustomerByNumber(int id)
    {
        try
        {
            await _articleService.DeleteArticleById(id);
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Could not delete article");
            return BadRequest(ex.Message);
        }
    }

}

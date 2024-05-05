using CodeTest.Contracts.Requests;
using CodeTest.Contracts.Response;

namespace CodeTest.Web.Services;

public class ArticleService(ApiService apiService)
{
    private readonly ApiService _apiService = apiService;

    public async Task<IEnumerable<ArticleResponse>> GetArticles()
    {
        var result = await _apiService.HttpRequest<IEnumerable<ArticleResponse>>("Article", HttpMethod.Get);
        return result;
    }

    public async Task<IEnumerable<ArticleResponse>> AddArticle(ArticleRequest request)
    {
        var result = await _apiService.HttpRequest<IEnumerable<ArticleResponse>>("Article", HttpMethod.Post, content: request);
        return result;
    }

    public async Task<IEnumerable<ArticleResponse>> DeleteArticle(int id)
    {
        var result = await _apiService.HttpRequest<IEnumerable<ArticleResponse>>($"Article/by-id/{id}", HttpMethod.Delete);
        return result;
    }

}

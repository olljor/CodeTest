using CodeTest.Contracts.Requests;
using CodeTest.Contracts.Response;
using CodeTest.Infrastructure.Entities;
using CodeTest.Infrastructure.Repositories;
using System.Data;
using Dapper;

namespace CodeTest.Core.Services;
public class ArticleService(IDbConnection connection)
{
    private readonly IDbConnection _connection = connection;

    public async Task<IEnumerable<ArticleResponse>> GetArticles()
    {
        var result = await _connection.QueryAsync<Article>(ArticleRepository.GetArticles);
        return result.Select(article => new ArticleResponse
        {
            ArticleId = article.ArticleId,
            Description = article.Description,
            Price = article.Price,
        });
    }

    public async Task DeleteArticleById(int id)
    {
        await _connection.ExecuteAsync(ArticleRepository.DeleteArticleById, new { Id = id });
    }

    public async Task AddArticle(ArticleRequest articleRequest)
    {
        await _connection.ExecuteAsync(ArticleRepository.AddArticle,
            new
            {
                articleRequest.ArticleId,
                articleRequest.Description,
                articleRequest.Price,
            });
    }
}

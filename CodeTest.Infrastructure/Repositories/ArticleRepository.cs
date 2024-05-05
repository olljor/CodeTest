using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Infrastructure.Repositories;
public static class ArticleRepository
{
    public static string GetArticles { get; private set; } = "SELECT * FROM [Article]";

    public static string DeleteArticleById { get; private set; } = """
    DELETE FROM [Article] 
    WHERE [ArticleId] = @Id
    """;

    public static string AddArticle { get; private set; } = """
    INSERT INTO [Article] 
    ([ArticleId], [Description], [Price]) 
    Values (@ArticleId, @Description, @Price)
    """;
}

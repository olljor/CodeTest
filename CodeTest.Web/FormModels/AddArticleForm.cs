using System.ComponentModel.DataAnnotations;

namespace CodeTest.Web.FormModels;

public class AddArticleForm
{
    [Required]
    public int ArticleId { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 1)]
    public string Description { get; set; }

    [Required]
    public decimal Price { get; set; }
}

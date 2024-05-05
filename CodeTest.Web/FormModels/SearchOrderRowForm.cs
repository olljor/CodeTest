using System.ComponentModel.DataAnnotations;

namespace CodeTest.Web.FormModels;

public class SearchOrderRowForm
{
    [Required]
    public int OrderId { get; set; }
    public int ArticleId { get; set; }
}

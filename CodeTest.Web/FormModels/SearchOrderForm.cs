using System.ComponentModel.DataAnnotations;

namespace CodeTest.Web.FormModels;

public class SearchOrderForm
{
    [Required]
    public int OrderId { get; set; }
}

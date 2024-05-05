using System.ComponentModel.DataAnnotations;

namespace CodeTest.Web.FormModels;

public class AddOrderForm
{
    [Required]
    public int CustomerNumber { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace CodeTest.Web.FormModels;

public class AddCustomerForm
{
    [Required]
    public int CustomerNumber { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 4)]
    public string CustomerName { get; set; }
}

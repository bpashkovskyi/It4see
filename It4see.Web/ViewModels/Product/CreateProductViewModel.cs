using System.ComponentModel.DataAnnotations;

namespace It4see.Web.ViewModels.Product;

public class CreateProductViewModel
{
    [Required]
    public string Title { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public int CategoryId { get; set; }
}
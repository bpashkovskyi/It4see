using System.ComponentModel.DataAnnotations;

namespace It4see.Web.ViewModels.Product;

public class UpdateProductViewModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }

    [Required]
    public decimal Price { get; set; }

    [Required]
    public int CategoryId { get; set; }
}
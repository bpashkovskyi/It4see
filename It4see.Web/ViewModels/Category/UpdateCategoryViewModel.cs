using System.ComponentModel.DataAnnotations;

namespace It4see.Web.ViewModels.Category;

public class UpdateCategoryViewModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }
}
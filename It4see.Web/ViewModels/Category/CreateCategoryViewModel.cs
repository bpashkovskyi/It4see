using System.ComponentModel.DataAnnotations;

namespace It4see.Web.ViewModels.Category;

public class CreateCategoryViewModel
{
    [Required]
    public string Title { get; set; }
}
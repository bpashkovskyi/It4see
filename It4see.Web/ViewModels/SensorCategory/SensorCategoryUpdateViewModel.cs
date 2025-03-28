using System.ComponentModel.DataAnnotations;

namespace It4see.Web.ViewModels.SensorCategory;

public class SensorCategoryUpdateViewModel
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string Title { get; set; }
}
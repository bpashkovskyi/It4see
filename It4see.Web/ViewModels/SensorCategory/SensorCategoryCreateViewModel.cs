using System.ComponentModel.DataAnnotations;

namespace It4see.Web.ViewModels.SensorCategory;

public class SensorCategoryCreateViewModel
{
    [Required]
    public string Title { get; set; }
}
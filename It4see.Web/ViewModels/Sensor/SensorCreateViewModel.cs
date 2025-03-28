using It4see.Domain.Enums;

using System.ComponentModel.DataAnnotations;

namespace It4see.Web.ViewModels.Sensor;

public class SensorCreateViewModel
{
    [Required]
    public string Name { get; set; }

    [Required]
    public SensorType SensorType { get; init; }

    [Required]
    public int SensorCategoryId { get; set; }
}
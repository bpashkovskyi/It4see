using It4see.Domain.Enums;

namespace It4see.Web.ViewModels.Sensor;

public class SensorDetailsViewModel
{
    public string Name { get; set; }

    public SensorType SensorType { get; init; }

    public string SensorCategoryTitle { get; init; }
}
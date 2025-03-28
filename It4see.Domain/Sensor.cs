using It4see.Domain.Enums;

namespace It4see.Domain;

public class Sensor
{
    public int Id { get; set; }

    public string Name { get; set; }

    public SensorType SensorType { get; set; }

    public int SensorCategoryId { get; set; }

    public SensorCategory SensorCategory { get; set; }
}
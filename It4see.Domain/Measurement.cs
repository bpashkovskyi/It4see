namespace It4see.Domain;

public class Measurement
{
    public double Value { get; set; }

    public int SensorId { get; set; }

    public Sensor Sensor { get; set; }
}
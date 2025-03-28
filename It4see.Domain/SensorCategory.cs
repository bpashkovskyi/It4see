namespace It4see.Domain;

public class SensorCategory
{
    public int Id { get; set; }

    public string Title { get; set; }

    public ICollection<Sensor> Sensors { get; set; }
}
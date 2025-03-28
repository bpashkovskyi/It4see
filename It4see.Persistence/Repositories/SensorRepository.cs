using It4see.Domain;
using It4see.Persistence.Base;
using Microsoft.EntityFrameworkCore;

namespace It4see.Persistence.Repositories;

public class SensorRepository(SensorsDatabaseContext dbContext) : ISensorRepository
{
    public async Task<List<Sensor>> GetAllAsync()
    {
        var sensors = await dbContext.Sensors
            .Include(sensor => sensor.SensorCategory)
            .ToListAsync();

        return sensors;
    }

    public async Task<Sensor> FindAsync(int id)
    {
        var sensor = await dbContext.Sensors
            .Include(sensor => sensor.SensorCategory)
            .FirstOrDefaultAsync(sensor => sensor.Id == id);

        return sensor;
    }

    public async Task<Sensor> FindByNameAsync(string name)
    {
        var sensor = await dbContext.Sensors
            .Include(sensor => sensor.SensorCategory)
            .FirstOrDefaultAsync(sensor => sensor.Name == name);

        return sensor;
    }

    public async Task AddAsync(Sensor sensor)
    {
        await dbContext.Sensors.AddAsync(sensor);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Sensor sensor)
    {
        var dbSensor = await dbContext.Sensors.FindAsync(sensor.Id);
        if (dbSensor == null)
        {
            throw new NullReferenceException();
        }

        dbSensor.Name = sensor.Name;
        dbSensor.SensorType = sensor.SensorType;
        dbSensor.SensorCategoryId = sensor.SensorCategoryId;

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var sensor = await dbContext.Sensors.FindAsync(id);
        if (sensor == null)
        {
            throw new NullReferenceException();
        }

        dbContext.Remove(sensor);

        await dbContext.SaveChangesAsync();
    }
}
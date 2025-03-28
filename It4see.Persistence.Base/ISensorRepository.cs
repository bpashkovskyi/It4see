using It4see.Domain;

namespace It4see.Persistence.Base;

public interface ISensorRepository
{
    Task<List<Sensor>> GetAllAsync();
    Task<Sensor> FindAsync(int id);
    Task<Sensor> FindByNameAsync(string name);
    Task AddAsync(Sensor sensorCategory);
    Task UpdateAsync(Sensor sensorCategory);
    Task DeleteAsync(int id);
}
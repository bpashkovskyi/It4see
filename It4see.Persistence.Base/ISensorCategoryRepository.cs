using It4see.Domain;

namespace It4see.Persistence.Base;

public interface ISensorCategoryRepository
{
    Task<List<SensorCategory>> GetAllAsync();
    Task<SensorCategory> FindAsync(int id);
    Task<SensorCategory> FindByTitleAsync(string title);
    Task AddAsync(SensorCategory sensorCategory);
    Task UpdateAsync(SensorCategory sensorCategory);
    Task DeleteAsync(int id);
}
using It4see.Domain;
using It4see.Persistence.Base;
using Microsoft.EntityFrameworkCore;

namespace It4see.Persistence.Repositories;

public class SensorCategoryRepository(SensorsDatabaseContext dbContext) : ISensorCategoryRepository
{
    public async Task<List<SensorCategory>> GetAllAsync()
    {
        return await dbContext.SensorCategories.ToListAsync();
    }

    public async Task<SensorCategory> FindAsync(int id)
    {
        return await dbContext.SensorCategories.FindAsync(id);
    }

    public async Task<SensorCategory> FindByTitleAsync(string title)
    {
        return await dbContext.SensorCategories.FirstOrDefaultAsync(c => c.Title == title);
    }

    public async Task AddAsync(SensorCategory sensorCategory)
    {
        await dbContext.SensorCategories.AddAsync(sensorCategory);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(SensorCategory sensorCategory)
    {
        var dbSensorCategory = await dbContext.SensorCategories.FindAsync(sensorCategory.Id);
        if (dbSensorCategory == null)
        {
            throw new NullReferenceException();
        }

        dbSensorCategory.Title = sensorCategory.Title;

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var sensorCategory = await dbContext.SensorCategories.FindAsync(id);
        if (sensorCategory == null)
        {
            throw new NullReferenceException();
        }

        dbContext.Remove(sensorCategory);

        await dbContext.SaveChangesAsync();
    }
}
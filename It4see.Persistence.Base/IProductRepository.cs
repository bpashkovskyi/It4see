using It4see.Domain;

namespace It4see.Persistence.Base;

public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product> FindAsync(int id);
    Task<Product> FindByTitleAsync(string title);
    Task AddAsync(Product category);
    Task UpdateAsync(Product category);
    Task DeleteAsync(int id);
}
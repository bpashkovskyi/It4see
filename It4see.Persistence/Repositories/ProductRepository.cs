using It4see.Domain;
using It4see.Persistence.Base;
using Microsoft.EntityFrameworkCore;

namespace It4see.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ShopDatabaseContext dbContext;

    public ProductRepository(ShopDatabaseContext dbContext)
    {
        this.dbContext = dbContext;
    }


    public async Task<List<Product>> GetAllAsync()
    {
        var products = await dbContext.Products
            .Include(product => product.Category)
            .ToListAsync();

        return products;
    }

    public async Task<Product> FindAsync(int id)
    {
        var product = await dbContext.Products
            .Include(product => product.Category)
            .FirstOrDefaultAsync(product => product.Id == id);

        return product;
    }

    public async Task<Product> FindByTitleAsync(string title)
    {
        var product = await dbContext.Products
            .Include(product => product.Category)
            .FirstOrDefaultAsync(product => product.Title == title);

        return product;
    }

    public async Task AddAsync(Product product)
    {
        await dbContext.Products.AddAsync(product);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        var dbProduct = await dbContext.Products.FindAsync(product.Id);
        if (dbProduct == null)
        {
            throw new NullReferenceException();
        }

        dbProduct.Title = product.Title;
        dbProduct.Price = product.Price;
        dbProduct.CategoryId = product.CategoryId;

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await dbContext.Products.FindAsync(id);
        if (product == null)
        {
            throw new NullReferenceException();
        }

        dbContext.Remove(product);

        await dbContext.SaveChangesAsync();
    }
}
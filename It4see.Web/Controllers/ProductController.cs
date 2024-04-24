using AutoMapper;

using It4see.Domain;
using It4see.Persistence;
using It4see.Web.ViewModels.Product;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace It4see.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ShopDatabaseContext dbContext;
    private readonly IMapper mapper;

    public ProductController(ShopDatabaseContext dbContext, IMapper mapper)
    {
        this.dbContext = dbContext;
        this.mapper = mapper;
    }

    [HttpGet("list")]
    public async Task<IActionResult> Get()
    {
        var products = await dbContext.Products
            .Include(product => product.Category)
            .ToListAsync();

        var productListViewModels = this.mapper.Map<List<ProductListViewModel>>(products);

        return Ok(productListViewModels);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await dbContext.Products
            .Include(product => product.Category)
            .FirstOrDefaultAsync(product => product.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        var productDetailsViewModel = this.mapper.Map<ProductDetailsViewModel>(product);

        return Ok(productDetailsViewModel);
    }

    [HttpGet("byTitle")]
    public async Task<IActionResult> GetByTitle(string title)
    {
        var product = await dbContext.Products
            .Include(product => product.Category)
            .FirstOrDefaultAsync(product => product.Title == title);

        if (product == null)
        {
            return NotFound();
        }

        var productDetailsViewModel = this.mapper.Map<ProductDetailsViewModel>(product);

        return Ok(productDetailsViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateProductViewModel createProductViewModel)
    {
        var product = this.mapper.Map<Product>(createProductViewModel);

        await dbContext.Products.AddAsync(product);
        await dbContext.SaveChangesAsync();

        return Created("test", product.Id);
    }

    [HttpPut]
    public async Task<IActionResult> Put(UpdateProductViewModel updateProductViewModel)
    {
        var product = await dbContext.Products.FindAsync(updateProductViewModel.Id);
        if (product == null)
        {
            return NotFound();
        }

        product.Title = updateProductViewModel.Title;
        product.Price = updateProductViewModel.Price;
        product.CategoryId = updateProductViewModel.CategoryId;

        await dbContext.SaveChangesAsync();

        return Ok(product);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await dbContext.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        dbContext.Remove(product);

        await dbContext.SaveChangesAsync();

        return NoContent();
    }
}
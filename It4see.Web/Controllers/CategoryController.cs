using It4see.Domain;
using It4see.Persistence.RepositoriesBase;

using Microsoft.AspNetCore.Mvc;

namespace It4see.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository categoryRepository;

    public CategoryController(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    [HttpGet("list")]
    public async Task<IActionResult> Get()
    {
        var categories = await this.categoryRepository.GetAllAsync();

        return Ok(categories);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await this.categoryRepository.FindAsync(id);
        if (category == null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    [HttpGet("byTitle")]
    public async Task<IActionResult> GetByTitle(string title)
    {
        var category = await this.categoryRepository.FindByTitleAsync(title);
        if (category == null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Category category)
    {
        await this.categoryRepository.AddAsync(category);

        return Ok(category);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Category category)
    {
        await this.categoryRepository.UpdateAsync(category);

        return Ok(category);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await this.categoryRepository.DeleteAsync(id);

        return NoContent();
    }
}
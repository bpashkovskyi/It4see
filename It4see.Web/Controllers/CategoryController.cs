using It4see.Application;
using It4see.Domain;
using It4see.Persistence.Base;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace It4see.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator mediator;

    public CategoryController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("list")]
    public async Task<IActionResult> Get()
    {
        var categories = await this.mediator.Send(new GetAllCategoriesQuery());

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
        var createCategoryCommand = new CreateCategoryCommand
        {
            Title = category.Title
        };

        await this.mediator.Send(createCategoryCommand);

        return Ok(category);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Category category)
    {
        var updateCategoryCommand = new UpdateCategoryCommand()
        {
            Id = category.Id,
            Title = category.Title
        };

        await this.mediator.Send(updateCategoryCommand);

        return Ok(category);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await this.categoryRepository.DeleteAsync(id);

        return NoContent();
    }
}
using AutoMapper;

using It4see.Application.Categories;
using It4see.Application.Products;
using It4see.Domain;
using It4see.Web.ViewModels.Product;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace It4see.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;

    public CategoryController(IMediator mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [HttpGet("list")]
    public async Task<IActionResult> Get()
    {
        var categories = await mediator.Send(new GetAllCategoriesQuery());

        var categoryListViewModels = mapper.Map<List<ProductListViewModel>>(categories);

        return Ok(categoryListViewModels);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        var category = await this.mediator.Send(new GetProductQuery { Id = id });
        if (category == null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    [HttpGet("byTitle")]
    public async Task<IActionResult> GetByTitle(string title)
    {
        var category = await this.mediator.Send(new GetProductByTitleQuery { Title = title });
        if (category == null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Product category)
    {
        var createProductCommand = new CreateProductCommand
        {
            Title = category.Title
        };

        await mediator.Send(createProductCommand);

        return Ok(category);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Product category)
    {
        var updateProductCommand = new UpdateProductCommand()
        {
            Id = category.Id,
            Title = category.Title
        };

        await mediator.Send(updateProductCommand);

        return Ok(category);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteProductCommand { Id = id });

        return NoContent();
    }
}
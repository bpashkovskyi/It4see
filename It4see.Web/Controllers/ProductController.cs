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
public class ProductController : ControllerBase
{
    private readonly IMediator mediator;
    private readonly IMapper mapper;

    public ProductController(IMediator mediator, IMapper mapper)
    {
        this.mediator = mediator;
        this.mapper = mapper;
    }

    [HttpGet("list")]
    public async Task<IActionResult> Get()
    {
        var categories = await mediator.Send(new GetAllCategoriesQuery());

        var productListViewModels = mapper.Map<List<ProductListViewModel>>(categories);

        return Ok(productListViewModels);
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await this.mediator.Send(new GetProductQuery { Id = id });
        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpGet("byTitle")]
    public async Task<IActionResult> GetByTitle(string title)
    {
        var product = await this.mediator.Send(new GetProductByTitleQuery { Title = title });
        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Product product)
    {
        var createProductCommand = new CreateProductCommand
        {
            Title = product.Title
        };

        await mediator.Send(createProductCommand);

        return Ok(product);
    }

    [HttpPut]
    public async Task<IActionResult> Put(Product product)
    {
        var updateProductCommand = new UpdateProductCommand()
        {
            Id = product.Id,
            Title = product.Title
        };

        await mediator.Send(updateProductCommand);

        return Ok(product);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteProductCommand { Id = id });

        return NoContent();
    }
}
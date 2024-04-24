using MediatR;

namespace It4see.Application.Products;

public class CreateProductCommand : IRequest
{
    public string Title { get; set; }

    public decimal Price { get; set; }

    public int CategoryId { get; set; }
}
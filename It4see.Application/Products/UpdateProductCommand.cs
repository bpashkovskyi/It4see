using MediatR;

namespace It4see.Application.Products;

public class UpdateProductCommand : IRequest
{
    public int Id { get; set; }

    public string Title { get; set; }

    public decimal Price { get; set; }

    public int CategoryId { get; set; }
}
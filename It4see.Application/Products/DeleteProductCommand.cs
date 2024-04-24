using MediatR;

namespace It4see.Application.Products;

public class DeleteProductCommand : IRequest
{
    public int Id { get; set; }
}
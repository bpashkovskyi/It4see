using It4see.Domain;

using MediatR;

namespace It4see.Application.Products;

public class GetProductQuery : IRequest<Product>
{
    public int Id { get; set; }
}
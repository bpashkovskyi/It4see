using It4see.Domain;

using MediatR;

namespace It4see.Application.Products;

public class GetProductByTitleQuery : IRequest<Product>
{
    public string Title { get; set; }
}
using It4see.Domain;

using MediatR;

namespace It4see.Application.Products;

public class GetAllProductsQuery : IRequest<List<Product>>
{
}
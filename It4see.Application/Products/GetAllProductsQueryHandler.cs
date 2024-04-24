using It4see.Domain;
using It4see.Persistence.Base;

using MediatR;

namespace It4see.Application.Products;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
{
    private readonly IProductRepository categoryRepository;

    public GetAllProductsQueryHandler(IProductRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var categories = await categoryRepository.GetAllAsync();

        return categories;
    }
}
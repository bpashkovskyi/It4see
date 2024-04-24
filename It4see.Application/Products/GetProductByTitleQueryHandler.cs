using It4see.Domain;
using It4see.Persistence.Base;

using MediatR;

namespace It4see.Application.Products;

public class GetProductByTitleQueryHandler : IRequestHandler<GetProductByTitleQuery, Product>
{
    private readonly IProductRepository categoryRepository;

    public GetProductByTitleQueryHandler(IProductRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    public async Task<Product> Handle(GetProductByTitleQuery request, CancellationToken cancellationToken)
    {
        return await this.categoryRepository.FindByTitleAsync(request.Title);
    }
}
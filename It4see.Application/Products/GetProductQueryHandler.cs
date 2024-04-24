using It4see.Domain;
using It4see.Persistence.Base;

using MediatR;

namespace It4see.Application.Products;

public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
{
    private readonly IProductRepository categoryRepository;

    public GetProductQueryHandler(IProductRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
    {
        return await this.categoryRepository.FindAsync(request.Id);
    }
}
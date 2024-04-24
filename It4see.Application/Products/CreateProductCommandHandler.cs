using It4see.Domain;
using It4see.Persistence.Base;

using MediatR;

namespace It4see.Application.Products;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly IProductRepository categoryRepository;

    public CreateProductCommandHandler(IProductRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var category = new Product
        {
            Title = request.Title,
            Price = request.Price,
            CategoryId = request.CategoryId
        };

        await categoryRepository.AddAsync(category);
    }
}
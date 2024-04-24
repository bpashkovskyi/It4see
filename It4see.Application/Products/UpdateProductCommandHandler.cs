using It4see.Domain;
using It4see.Persistence.Base;

using MediatR;

namespace It4see.Application.Products;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IProductRepository categoryRepository;

    public UpdateProductCommandHandler(IProductRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var category = new Product
        {
            Id = request.Id,
            Title = request.Title,
            Price = request.Price,
            CategoryId = request.CategoryId
        };

        await categoryRepository.UpdateAsync(category);
    }
}
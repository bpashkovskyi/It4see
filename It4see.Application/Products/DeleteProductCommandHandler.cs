using It4see.Persistence.Base;

using MediatR;

namespace It4see.Application.Products;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductRepository categoryRepository;

    public DeleteProductCommandHandler(IProductRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        await categoryRepository.DeleteAsync(request.Id);
    }
}
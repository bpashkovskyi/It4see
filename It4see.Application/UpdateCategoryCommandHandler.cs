using It4see.Domain;
using It4see.Persistence.Base;

using MediatR;

namespace It4see.Application;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository categoryRepository;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category
        {
            Id = request.Id,
            Title = request.Title
        };

        await this.categoryRepository.UpdateAsync(category);
    }
}
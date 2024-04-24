using It4see.Domain;
using It4see.Persistence.Base;

using MediatR;

namespace It4see.Application.Categories;

public class GetCategoryByTitleQueryHandler : IRequestHandler<GetCategoryByTitleQuery, Category>
{
    private readonly ICategoryRepository categoryRepository;

    public GetCategoryByTitleQueryHandler(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    public async Task<Category> Handle(GetCategoryByTitleQuery request, CancellationToken cancellationToken)
    {
        return await this.categoryRepository.FindByTitleAsync(request.Title);
    }
}
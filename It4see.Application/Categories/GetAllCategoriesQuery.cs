using It4see.Domain;

using MediatR;

namespace It4see.Application.Categories;

public class GetAllCategoriesQuery : IRequest<List<Category>>
{
}
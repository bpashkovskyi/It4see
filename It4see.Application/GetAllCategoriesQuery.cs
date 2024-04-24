using It4see.Domain;

using MediatR;

namespace It4see.Application;

public class GetAllCategoriesQuery : IRequest<List<Category>>
{
}
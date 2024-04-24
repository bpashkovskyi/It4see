using It4see.Domain;

using MediatR;

namespace It4see.Application.Categories;

public class GetCategoryQuery : IRequest<Category>
{
    public int Id { get; set; }
}
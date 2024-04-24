using MediatR;

namespace It4see.Application.Categories;

public class DeleteCategoryCommand : IRequest
{
    public int Id { get; set; }
}
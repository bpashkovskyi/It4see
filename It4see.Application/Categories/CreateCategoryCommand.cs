using MediatR;

namespace It4see.Application.Categories;

public class CreateCategoryCommand : IRequest
{
    public string Title { get; set; }
}
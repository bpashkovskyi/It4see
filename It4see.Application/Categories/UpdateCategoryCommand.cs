using MediatR;

namespace It4see.Application.Categories;

public class UpdateCategoryCommand : IRequest
{
    public int Id { get; set; }

    public string Title { get; set; }
}
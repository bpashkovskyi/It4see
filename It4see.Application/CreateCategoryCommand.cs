using MediatR;

namespace It4see.Application;

public class CreateCategoryCommand : IRequest
{
    public string Title { get; set; }
}
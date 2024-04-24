using MediatR;

namespace It4see.Application;

public class GetCategoryByTitleQuery : IRequest
{
    public int Title { get; set; }
}
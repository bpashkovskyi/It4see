using MediatR;

namespace It4see.Application;

public class GetCategoryQuery : IRequest
{
    public int Id { get; set;}
}
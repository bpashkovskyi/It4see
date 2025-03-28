using It4see.Domain;
using MediatR;

namespace It4see.Application.SensorCategories;

public class GetSensorCategoryByTitleQuery : IRequest<SensorCategory>
{
    public string Title { get; init; }
}
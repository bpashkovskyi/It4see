using It4see.Domain;
using MediatR;

namespace It4see.Application.SensorCategories;

public class GetSensorCategoryQuery : IRequest<SensorCategory>
{
    public int Id { get; init; }
}
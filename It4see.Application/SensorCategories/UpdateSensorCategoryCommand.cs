using MediatR;

namespace It4see.Application.SensorCategories;

public class UpdateSensorCategoryCommand : IRequest
{
    public int Id { get; init; }

    public string Title { get; init; }
}
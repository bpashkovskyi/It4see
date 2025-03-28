using MediatR;

namespace It4see.Application.SensorCategories;

public class DeleteSensorCategoryCommand : IRequest
{
    public int Id { get; init; }
}
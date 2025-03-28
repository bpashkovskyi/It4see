using MediatR;

namespace It4see.Application.SensorCategories;

public class CreateSensorCategoryCommand : IRequest
{
    public string Title { get; set; }
}
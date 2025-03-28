using It4see.Domain.Enums;

using MediatR;

namespace It4see.Application.Sensors;

public class CreateSensorCommand : IRequest
{
    public string Name { get; init; }

    public SensorType SensorType { get; init; }

    public int SensorCategoryId { get; init; }
}
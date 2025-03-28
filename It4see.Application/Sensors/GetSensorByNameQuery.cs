using It4see.Domain;
using MediatR;

namespace It4see.Application.Sensors;

public class GetSensorByNameQuery : IRequest<Sensor>
{
    public string Name { get; init; }
}
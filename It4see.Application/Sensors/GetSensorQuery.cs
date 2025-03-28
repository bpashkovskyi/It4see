using It4see.Domain;
using MediatR;

namespace It4see.Application.Sensors;

public class GetSensorQuery : IRequest<Sensor>
{
    public int Id { get; init; }
}
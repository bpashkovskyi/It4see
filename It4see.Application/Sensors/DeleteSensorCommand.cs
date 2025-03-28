using MediatR;

namespace It4see.Application.Sensors;

public class DeleteSensorCommand : IRequest
{
    public int Id { get; set; }
}
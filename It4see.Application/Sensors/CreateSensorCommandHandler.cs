using It4see.Domain;
using It4see.Persistence.Base;
using MediatR;

namespace It4see.Application.Sensors;

public class CreateSensorCommandHandler(ISensorRepository sensorRepository)
    : IRequestHandler<CreateSensorCommand>
{
    public async Task Handle(CreateSensorCommand request, CancellationToken cancellationToken)
    {
        var sensor = new Sensor
        {
            Name = request.Name,
            SensorType = request.SensorType,
            SensorCategoryId = request.SensorCategoryId
        };

        await sensorRepository.AddAsync(sensor);
    }
}
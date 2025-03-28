using It4see.Domain;
using It4see.Persistence.Base;
using MediatR;

namespace It4see.Application.Sensors;

public class UpdateSensorCommandHandler(ISensorRepository sensorRepository)
    : IRequestHandler<UpdateSensorCommand>
{
    public async Task Handle(UpdateSensorCommand request, CancellationToken cancellationToken)
    {
        var sensorCategory = new Sensor
        {
            Id = request.Id,
            Name = request.Name,
            SensorType = request.SensorType,
            SensorCategoryId = request.SensorCategoryId
        };

        await sensorRepository.UpdateAsync(sensorCategory);
    }
}
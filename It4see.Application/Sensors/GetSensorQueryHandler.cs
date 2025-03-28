using It4see.Domain;
using It4see.Persistence.Base;
using MediatR;

namespace It4see.Application.Sensors;

public class GetSensorQueryHandler(ISensorRepository sensorRepository) : IRequestHandler<GetSensorQuery, Sensor>
{
    public async Task<Sensor> Handle(GetSensorQuery request, CancellationToken cancellationToken)
    {
        return await sensorRepository.FindAsync(request.Id);
    }
}
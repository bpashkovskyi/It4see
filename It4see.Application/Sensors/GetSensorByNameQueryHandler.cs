using It4see.Domain;
using It4see.Persistence.Base;
using MediatR;

namespace It4see.Application.Sensors;

public class GetSensorByNameQueryHandler(ISensorRepository sensorRepository)
    : IRequestHandler<GetSensorByNameQuery, Sensor>
{
    public async Task<Sensor> Handle(GetSensorByNameQuery request, CancellationToken cancellationToken)
    {
        return await sensorRepository.FindByNameAsync(request.Name);
    }
}
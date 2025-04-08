using It4see.Domain;
using It4see.Persistence.Base;
using MediatR;

namespace It4see.Application.Sensors;

public class GetAllSensorsQueryHandler(ISensorRepository sensorRepository)
    : IRequestHandler<GetAllSensorsQuery, List<Sensor>>
{
    public async Task<List<Sensor>> Handle(GetAllSensorsQuery request, CancellationToken cancellationToken)
    {
        List<Sensor> sensors = await sensorRepository.GetAllAsync();

        return sensors;
    }
}
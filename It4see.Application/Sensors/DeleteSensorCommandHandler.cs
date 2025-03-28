using It4see.Persistence.Base;
using MediatR;

namespace It4see.Application.Sensors;

public class DeleteSensorCommandHandler(ISensorRepository sensorRepository)
    : IRequestHandler<DeleteSensorCommand>
{
    public async Task Handle(DeleteSensorCommand request, CancellationToken cancellationToken)
    {
        await sensorRepository.DeleteAsync(request.Id);
    }
}
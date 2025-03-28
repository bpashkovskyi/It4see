using It4see.Persistence.Base;
using MediatR;

namespace It4see.Application.SensorCategories;

public class DeleteSensorCategoryCommandHandler(ISensorCategoryRepository sensorCategoryRepository)
    : IRequestHandler<DeleteSensorCategoryCommand>
{
    public async Task Handle(DeleteSensorCategoryCommand request, CancellationToken cancellationToken)
    {
        await sensorCategoryRepository.DeleteAsync(request.Id);
    }
}
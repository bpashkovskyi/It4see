using It4see.Domain;
using It4see.Persistence.Base;
using MediatR;

namespace It4see.Application.SensorCategories;

public class UpdateSensorCategoryCommandHandler(ISensorCategoryRepository sensorCategoryRepository)
    : IRequestHandler<UpdateSensorCategoryCommand>
{
    public async Task Handle(UpdateSensorCategoryCommand request, CancellationToken cancellationToken)
    {
        SensorCategory sensorCategory = new SensorCategory
        {
            Id = request.Id,
            Title = request.Title
        };

        await sensorCategoryRepository.UpdateAsync(sensorCategory);
    }
}
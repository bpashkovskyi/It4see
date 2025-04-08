using It4see.Domain;
using It4see.Persistence.Base;
using MediatR;

namespace It4see.Application.SensorCategories;

public class CreateSensorCategoryCommandHandler(ISensorCategoryRepository sensorCategoryRepository)
    : IRequestHandler<CreateSensorCategoryCommand>
{
    public async Task Handle(CreateSensorCategoryCommand request, CancellationToken cancellationToken)
    {
        SensorCategory sensorCategory = new SensorCategory
        {
            Title = request.Title
        };

        await sensorCategoryRepository.AddAsync(sensorCategory);
    }
}
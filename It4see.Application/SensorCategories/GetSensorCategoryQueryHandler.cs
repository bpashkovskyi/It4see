using It4see.Domain;
using It4see.Persistence.Base;
using MediatR;

namespace It4see.Application.SensorCategories;

public class GetSensorCategoryQueryHandler(ISensorCategoryRepository sensorCategoryRepository)
    : IRequestHandler<GetSensorCategoryQuery, SensorCategory>
{
    public async Task<SensorCategory> Handle(GetSensorCategoryQuery request, CancellationToken cancellationToken)
    {
        return await sensorCategoryRepository.FindAsync(request.Id);
    }
}
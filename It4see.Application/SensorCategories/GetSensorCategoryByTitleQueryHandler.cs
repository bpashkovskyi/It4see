using It4see.Domain;
using It4see.Persistence.Base;
using MediatR;

namespace It4see.Application.SensorCategories;

public class GetSensorCategoryByTitleQueryHandler(ISensorCategoryRepository sensorCategoryRepository)
    : IRequestHandler<GetSensorCategoryByTitleQuery, SensorCategory>
{
    public async Task<SensorCategory> Handle(GetSensorCategoryByTitleQuery request, CancellationToken cancellationToken)
    {
        return await sensorCategoryRepository.FindByTitleAsync(request.Title);
    }
}
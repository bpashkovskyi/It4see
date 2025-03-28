using It4see.Domain;
using It4see.Persistence.Base;
using MediatR;

namespace It4see.Application.SensorCategories;

public class GetAllSensorCategoriesQueryHandler(ISensorCategoryRepository sensorCategoryRepository)
    : IRequestHandler<GetAllSensorCategoriesQuery, List<SensorCategory>>
{
    public async Task<List<SensorCategory>> Handle(GetAllSensorCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await sensorCategoryRepository.GetAllAsync();

        return categories;
    }
}
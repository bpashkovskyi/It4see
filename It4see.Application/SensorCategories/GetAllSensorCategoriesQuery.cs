using It4see.Domain;
using MediatR;

namespace It4see.Application.SensorCategories;

public class GetAllSensorCategoriesQuery : IRequest<List<SensorCategory>>;
using It4see.Domain;
using MediatR;

namespace It4see.Application.Sensors;

public class GetAllSensorsQuery : IRequest<List<Sensor>>;
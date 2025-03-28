using AutoMapper;
using It4see.Application.Sensors;
using It4see.Domain;
using It4see.Web.ViewModels.Sensor;

namespace It4see.Web.Mapping;

public class SensorProfile : Profile
{
    public SensorProfile()
    {
        CreateMap<SensorCreateViewModel, CreateSensorCommand>();
        CreateMap<SensorUpdateViewModel, UpdateSensorCommand>();

        CreateMap<Sensor, SensorListViewModel>()
            .ForMember(sensorListViewModel => sensorListViewModel.SensorCategoryTitle, option => option.MapFrom(sensor => sensor.SensorCategory.Title));

        CreateMap<Sensor, SensorDetailsViewModel>()
            .ForMember(sensorDetailsViewModel => sensorDetailsViewModel.SensorCategoryTitle, option => option.MapFrom(sensor => sensor.SensorCategory.Title));
    }
}
using AutoMapper;
using It4see.Application.SensorCategories;
using It4see.Domain;
using It4see.Web.ViewModels.SensorCategory;

namespace It4see.Web.Mapping;

public class SensorCategoryProfile : Profile
{
    public SensorCategoryProfile()
    {
        CreateMap<SensorCategoryCreateViewModel, CreateSensorCategoryCommand>();
        CreateMap<SensorCategoryUpdateViewModel, UpdateSensorCategoryCommand>();

        CreateMap<SensorCategory, SensorCategoryListViewModel>();
        CreateMap<SensorCategory, SensorCategoryDetailsViewModel>();
    }
}
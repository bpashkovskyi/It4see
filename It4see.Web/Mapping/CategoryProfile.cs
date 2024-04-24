using AutoMapper;

using It4see.Domain;
using It4see.Web.ViewModels.Category;

namespace It4see.Web.Mapping;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<CreateCategoryViewModel, Category>();
        CreateMap<UpdateCategoryViewModel, Category>();

        CreateMap<Category, CategoryListViewModel>();

        CreateMap<Category, CategoryDetailsViewModel>();
    }
}
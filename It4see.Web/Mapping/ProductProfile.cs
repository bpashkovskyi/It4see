using AutoMapper;

using It4see.Domain;
using It4see.Web.ViewModels.Product;

namespace It4see.Web.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<CreateProductViewModel, Product>();
        CreateMap<UpdateProductViewModel, Product>();

        CreateMap<Product, ProductListViewModel>()
            .ForMember(productListViewModel => productListViewModel.CategoryName, option => option.MapFrom(product => product.Category.Title));

        CreateMap<Product, ProductDetailsViewModel>()
            .ForMember(productListViewModel => productListViewModel.CategoryName, option => option.MapFrom(product => product.Category.Title));
    }
}
using AutoMapper;
using CoffeeShop.Products.Api.Models.Dto;
using CoffeeShop.Products.Api.Models;

namespace CoffeeShop.Products.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.CategoryName.ToString()));
            CreateMap<Supplier, SupplierDto>()
                .ForMember(dest => dest.ProductsCount, opt => opt.MapFrom(src => src.Products.Count));
            CreateMap<ProductRating, ProductRatingDto>();
            CreateMap<ProductDto, Product>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => Enum.Parse<CategoryName>(src.Category)));
            CreateMap<SupplierDto, Supplier>();
            CreateMap<ProductRatingDto, ProductRating>();
        }
    }
}

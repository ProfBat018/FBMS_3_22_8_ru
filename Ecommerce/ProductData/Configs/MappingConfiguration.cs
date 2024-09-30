
using AutoMapper;
using ProductData.DTO;
using ProductData.Models;

namespace ProductData.Configs;

public class MappingConfiguration
{
    public static Mapper InitializeConfig()
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {

            cfg.CreateMap<Category, CategoryDTO>()
             .ConstructUsing(src => new CategoryDTO(src.CategoryId, src.Name, src.ParentCategoryId))
                .ForMember(
                    dest => dest.name,
                    x => x.MapFrom(u => u.Name))
                    .ForMember(
                    dest => dest.id,
                    x => x.MapFrom(u => u.CategoryId))
                .ForMember(
                    dest => dest.parentCategoryId,
                    x => x.MapFrom(u => u.ParentCategoryId));


            cfg.CreateMap<Product, AddProductDTO>()
               .ConstructUsing(src => new AddProductDTO(src.Name, src.ImageUrl, src.Description, src.Price, null)).ReverseMap();


            cfg.CreateMap<Product, ProductDTO>()
               .ConstructUsing(src => new ProductDTO(src.ProductId, src.Name, src.ImageUrl, src.Description, src.Price));


        });

        var mapper = new Mapper(mapperConfig);

        return mapper;
    }
}
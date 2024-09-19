
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

            cfg.CreateMap<Product, ProductDTO>()
                 .ForMember(
                    dest => dest.id,
                    x => x.MapFrom(u => u.ProductId))
                .ForMember(
                    dest => dest.name,
                    x => x.MapFrom(u => u.Name))
                .ForMember(
                    dest => dest.description,
                    x => x.MapFrom(u => u.Description))
                .ForMember(
                    dest => dest.price,
                    x => x.MapFrom(u => u.Price)).ReverseMap();

        });

        var mapper = new Mapper(mapperConfig);

        return mapper;
    }
}
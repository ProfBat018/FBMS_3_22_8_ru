
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
                .ForMember(
                    dest => dest.name, 
                    x => x.MapFrom(u => u.Name))
                .ForMember(
                    dest => dest.parentCategory, 
                    x => x.MapFrom(u => u.ParentCategory));
            
          
        });

        var mapper = new Mapper(mapperConfig);

        return mapper;
    }
}
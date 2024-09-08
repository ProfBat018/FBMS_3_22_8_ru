using AuthData.DTO;
using AuthData.Models;
using AutoMapper;

namespace AuthData.Configs;

public class MappingConfiguration
{
    public static Mapper InitializeConfig()
    {
        var mapperConfig = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, RegisterDTO>()
                .ForMember(
                    dest => dest.Username, 
                    x => x.MapFrom(u => u.Username));
            
          
            cfg.CreateMap<User, RegisterDTO>()
                .ForMember(
                    dest => dest.Email, 
                    x => x.MapFrom(u => u.Email));
        });

        var mapper = new Mapper(mapperConfig);

        return mapper;
    }
}
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
            
            cfg.CreateMap<AppRole, RoleDTO>()
                .ForMember(
                    dest => dest.name, 
                    x => x.MapFrom(u => u.Name)).ReverseMap();
            
        });

        var mapper = new Mapper(mapperConfig);

        return mapper;
    }
}
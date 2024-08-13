using AutoMapper;
using LiraLink.DTOs;
using LiraLink.Models;
using System.Text;

namespace LiraLink.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        {
            CreateMap<UserDto, UsersModel>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => Encoding.UTF8.GetBytes(src.Password)));

            CreateMap<UsersModel, UserDto>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => Encoding.UTF8.GetString(src.Password)));

            CreateMap<ClientsModel, ClientDto>();
            CreateMap<ClientDto, ClientsModel>();
        }
    }
}

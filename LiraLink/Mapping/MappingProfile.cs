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
            CreateMap<UsuarioDto, UsariosModel>()
                .ForMember(dest => dest.senha, opt => opt.MapFrom(src => Encoding.UTF8.GetBytes(src.senha)));

            CreateMap<UsariosModel, UsuarioDto>()
                .ForMember(dest => dest.senha, opt => opt.MapFrom(src => Encoding.UTF8.GetString(src.senha)));

            CreateMap<ClienteModel, ClienteDto>();
            CreateMap<ClienteDto, ClienteModel>();
            CreateMap<CargoModel, PositionDto>();
            CreateMap<PositionDto, CargoModel>();
            CreateMap<DepartamentoDto, DepartamentoModel>();
            CreateMap<DepartamentoModel, DepartamentoDto>();
            CreateMap<ProjetoModel, ProjetoDto>();
            CreateMap<ProjetoDto, ProjetoModel>();

        }
    }
}

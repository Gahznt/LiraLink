using AutoMapper;
using LiraLink.DTOs;
using LiraLink.Models;
using LiraLink.Repositories.UserRepository;
using LiraLink.Services.PositionService;

namespace LiraLink.Services.UserService;

public class UsuarioService : IUsuarioService
{
    private readonly IMapper _mapper;
    private readonly IUsuarioRepository _repository;
    private readonly ICargoService _positionService;
    public UsuarioService(IMapper mapper, IUsuarioRepository repository, ICargoService positionService)
    {
        _mapper = mapper;
        _repository = repository;
        _positionService = positionService;
    }
    public async Task<ServiceResponse<UsuarioDto>> CriaAsync(UsuarioDto userDto)
    {
        ServiceResponse<UsuarioDto> serviceResponse = new ServiceResponse<UsuarioDto>();

        var positionExists = await _positionService.BuscaPorIdAsync(userDto.cargo_id.Value);
        if (positionExists.StatusCode == 404)
        { 
            serviceResponse.Success = false;
            serviceResponse.Message = positionExists.Message;
            serviceResponse.StatusCode = positionExists.StatusCode;
            return serviceResponse;
        }
        
        var newUser = await _repository.CriarAsync(userDto);
        serviceResponse.StatusCode = 201;

        return serviceResponse;
    }

    public async Task<UsariosModel> BuscaPorEmailAsync(string email)
    {
        var user = await _repository.BuscaPorEmail(email);
        return user;
    }

    public async Task<UsariosModel> BuscaPorIdAsync(int id)
    {
        var user = await _repository.BuscaPorId(id);
        return user;
    }

    public async Task<UsuarioDto> AtualizaAsync(UsuarioDto userDto)
    {
        var changedUser = await _repository.AtualizaAsync(userDto);
        return _mapper.Map<UsuarioDto>(changedUser);
    }
}

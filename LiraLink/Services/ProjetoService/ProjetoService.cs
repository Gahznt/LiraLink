using AutoMapper;
using LiraLink.DTOs;
using LiraLink.Models;
using LiraLink.Repositories.ProjetoRepository;
using LiraLink.Services.ClientService;

namespace LiraLink.Services.ProjetoService;

public class ProjetoService : IProjetoService
{
    private readonly IMapper _mapper;
    private readonly IClienteService _clienteService;
    private readonly IProjetoRepository _projetoRepository;
    public ProjetoService(IMapper mapper, IClienteService clienteService, IProjetoRepository projetoRepository)
    {
        _mapper = mapper;
        _clienteService = clienteService;
        _projetoRepository = projetoRepository;
    }
    public async Task<ServiceResponse<ProjetoModel>> Criar(ProjetoDto projetoDto, int userId)
    {
        ServiceResponse<ProjetoModel> serviceResponse = new ServiceResponse<ProjetoModel>();
        var projeto = _mapper.Map<ProjetoModel>(projetoDto);
        projeto.criado_por = userId;

        var clienteExiste = await _clienteService.BuscaCliente(projeto.cliente_id);
        if(clienteExiste.StatusCode == 404)
        {
            serviceResponse.Message = clienteExiste.Message;
            serviceResponse.Success = clienteExiste.Success;
            serviceResponse.StatusCode = clienteExiste.StatusCode;
            return serviceResponse;
        }

        var novoProjeto = await _projetoRepository.CriarAsync(projeto);

        serviceResponse.Message = "Project successfully registered";
        serviceResponse.Data = novoProjeto;
        serviceResponse.StatusCode = 201;
        return serviceResponse;
    }
}

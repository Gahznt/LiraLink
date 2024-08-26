using AutoMapper;
using LiraLink.DTOs;
using LiraLink.Models;
using LiraLink.Repositories.ProjetoDepartamentoRepository;
using LiraLink.Services.ProjetoService;

namespace LiraLink.Services.ProjetoDepartamentoService;

public class ProjetoDepartamentoService : IProjetoDepartamentoService
{
    private readonly IMapper _mapper;
    private readonly IProjetoDepartamentoRepository _projetoDepartamentoRepository;
    private readonly IProjetoService _projetoService;
    public ProjetoDepartamentoService(IMapper mapper, IProjetoDepartamentoRepository projetoDepartamentoRepository, IProjetoService projetoService)
    {
        _mapper = mapper;
        _projetoService = projetoService;
        _projetoDepartamentoRepository = projetoDepartamentoRepository;
    }
    public Task<ServiceResponse<ProjetoDepartamentosModel>> Criar(ProjetoDepartamentoDto data)
    {
        throw new NotImplementedException();
    }
}

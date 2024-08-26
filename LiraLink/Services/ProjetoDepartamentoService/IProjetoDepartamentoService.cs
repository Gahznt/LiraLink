using LiraLink.DTOs;
using LiraLink.Models;

namespace LiraLink.Services.ProjetoDepartamentoService;

public interface IProjetoDepartamentoService
{
    Task<ServiceResponse<ProjetoDepartamentosModel>> Criar(ProjetoDepartamentoDto data);
}

using LiraLink.DTOs;
using LiraLink.Models;

namespace LiraLink.Services.ProjetoService;

public interface IProjetoService
{
    Task<ServiceResponse<ProjetoModel>> Criar(ProjetoDto projeto, int userId);
}

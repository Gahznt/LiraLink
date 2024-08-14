using LiraLink.DTOs;
using LiraLink.Models;

namespace LiraLink.Services.DepartmentService;

public interface IDepartmentService
{
    Task<ServiceResponse<DepartamentoModel>> BuscaPorIdAsync(int id);
    Task<ServiceResponse<List<DepartamentoModel>>> ListaAsync();
    Task<ServiceResponse<DepartamentoModel>> CriaAsync(DepartamentoDto department);
    Task<ServiceResponse<DepartamentoModel>> AtualizaAsync(int id, DepartamentoDto client);
}

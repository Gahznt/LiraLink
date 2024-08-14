using LiraLink.DTOs;
using LiraLink.Models;

namespace LiraLink.Repositories.DepartmentRepository;

public interface IDepartmentoRepository
{
    Task<List<DepartamentoModel>> ListaAsync();
    Task<DepartamentoModel> CriaAsync(DepartamentoModel position);
    Task<DepartamentoModel?> BuscaPorIdAsync(int id);
    Task<DepartamentoModel?> BuscaPorNomeAsync(string name);
    Task<DepartamentoModel> AtualizaAsync(DepartamentoModel client, DepartamentoDto data);
}

using LiraLink.DTOs;
using LiraLink.Models;

namespace LiraLink.Repositories.ProjetoRepository;

public interface IProjetoRepository
{
    Task<List<ProjetoModel>?> ListarAsync();
    Task<ProjetoModel?> BuscaPorNomeAsync(string name);
    Task<ProjetoModel?> BuscaPorIdAsync(int id);
    Task<ProjetoModel> CriarAsync(ProjetoModel client);
    Task<ProjetoModel> AtualizarAsync(ProjetoModel client, ProjetoDto data);
}

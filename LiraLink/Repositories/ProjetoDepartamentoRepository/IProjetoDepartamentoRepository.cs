using LiraLink.Models;

namespace LiraLink.Repositories.ProjetoDepartamentoRepository;

public interface IProjetoDepartamentoRepository
{
    Task<ProjetoDepartamentosModel> CriarAsync(ProjetoDepartamentosModel data);
}

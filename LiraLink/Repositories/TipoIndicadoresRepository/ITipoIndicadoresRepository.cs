using LiraLink.DTOs;
using LiraLink.Models;

namespace LiraLink.Repositories.IndicatorsTypeRepository;

public interface ITipoIndicadoresRepository
{
    Task<TipoIndicadorModel> CriaAsync(TipoIndicadoreseDto indicatorTypeDto);
    Task<List<TipoIndicadorModel>?> ListaAsync();
}

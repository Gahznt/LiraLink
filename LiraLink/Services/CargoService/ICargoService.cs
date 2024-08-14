using LiraLink.DTOs;
using LiraLink.Models;

namespace LiraLink.Services.PositionService;

public interface ICargoService
{
    Task<ServiceResponse<CargoModel>> BuscaPorIdAsync(int id);
    Task<ServiceResponse<List<CargoModel>>> ListaAsync();
    Task<ServiceResponse<CargoModel>> CriaAsync(PositionDto position);
    Task<ServiceResponse<PositionDto>> AtualizaAsync(int id, PositionDto position);
}

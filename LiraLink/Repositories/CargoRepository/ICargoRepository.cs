using LiraLink.DTOs;
using LiraLink.Models;

namespace LiraLink.Repositories.PositionsRepository;

public interface ICargoRepository
{
    Task<List<CargoModel>> ListaAsync();
    Task<CargoModel> CriaAsync(CargoModel position);
    Task<CargoModel?> BuscaPorIdAsync(int id);
    Task<CargoModel?> BuscaPorNomeAsync(string name);
    Task<CargoModel> AtualizaAsync(CargoModel position, PositionDto data);
}

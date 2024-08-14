using LiraLink.DTOs;
using LiraLink.Models;

namespace LiraLink.Services.UserService;

public interface IUsuarioService
{
    Task<ServiceResponse<UsuarioDto>> CriaAsync(UsuarioDto user);
    Task<UsuarioDto> AtualizaAsync(UsuarioDto user);
    Task<UsariosModel> BuscaPorEmailAsync(string email);
    Task<UsariosModel> BuscaPorIdAsync(int id);
}

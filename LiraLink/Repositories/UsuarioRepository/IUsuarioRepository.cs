using LiraLink.DTOs;
using LiraLink.Models;

namespace LiraLink.Repositories.UserRepository;

public interface IUsuarioRepository
{
    Task<UsariosModel> CriarAsync(UsuarioDto client);
    Task<UsariosModel> AtualizaAsync(UsuarioDto client);
    Task<UsariosModel> BuscaPorEmail(string email);
    Task<UsariosModel> BuscaPorId(int id);
}

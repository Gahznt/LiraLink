using LiraLink.DTOs;
using LiraLink.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LiraLink.Repositories.ClientRepository;

public interface IClienteRepository
{
    Task<List<ClienteModel>?> ListaClientes();
    Task<ClienteModel?> BuscaClientePorNome(string name);
    Task<ClienteModel?> BuscaClientePorId(int id);
    Task<ClienteModel> CriaCliente(ClienteDto client);
    Task<ClienteModel> AtualizaCliente(ClienteModel client, ClienteDto data);
}

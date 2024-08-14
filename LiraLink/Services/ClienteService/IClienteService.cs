using LiraLink.DTOs;
using LiraLink.Models;

namespace LiraLink.Services.ClientService;

public interface IClienteService
{
    Task<ServiceResponse<List<ClienteModel>>> ListaClientes();
    Task<ServiceResponse<ClienteModel>> BuscaCliente(int id);
    Task<ServiceResponse<ClienteModel>> CriaCliente(ClienteDto client);
    Task<ServiceResponse<ClienteModel>> AtualizaCliente(int id, ClienteDto client);
}

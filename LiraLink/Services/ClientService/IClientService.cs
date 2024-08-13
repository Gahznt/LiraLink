using LiraLink.DTOs;
using LiraLink.Models;

namespace LiraLink.Services.ClientService;

public interface IClientService
{
    Task<ServiceResponse<List<ClientsModel>>> GetClients();
    Task<ServiceResponse<ClientsModel>> GetClient(int id);
    Task<ServiceResponse<ClientsModel>> CreateClient(ClientDto client);
    Task<ServiceResponse<ClientsModel>> UpdateClient(int id, ClientDto client);
}

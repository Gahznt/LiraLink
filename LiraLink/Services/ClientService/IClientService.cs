using LiraLink.Models;

namespace LiraLink.Services.ClientService;

public interface IClientService
{
    Task<ServiceResponse<List<ClientsModel>>> GetClients();
    Task<ServiceResponse<ClientsModel>> GetClientById(int clientId);
    Task<ServiceResponse<List<ClientsModel>>> CreateClient(ClientsModel client);
    Task<ServiceResponse<List<ClientsModel>>> UpdateClient(ClientsModel client);
}

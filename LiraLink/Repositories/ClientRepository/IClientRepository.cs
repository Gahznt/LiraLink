using LiraLink.DTOs;
using LiraLink.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LiraLink.Repositories.ClientRepository;

public interface IClientRepository
{
    Task<List<ClientsModel>?> GetClientList();
    Task<ClientsModel?> GetClientByName(string name);
    Task<ClientsModel?> GetClientById(int id);
    Task<ClientsModel> CreateClient(ClientDto client);
    Task<ClientsModel> UpdateClient(ClientsModel client, ClientDto data);
}

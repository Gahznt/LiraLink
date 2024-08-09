using LiraLink.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LiraLink.Repositories.ClientRepository;

public interface IClientRepository
{
    Task<List<ClientsModel>> GetClientList();
}

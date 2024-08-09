using LiraLink.DataContext;
using LiraLink.Models;

namespace LiraLink.Repositories.ClientRepository;

public class ClientRepository : IClientRepository
{
    private readonly ApplicationDbContext _context;
    public ClientRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<ClientsModel>> GetClientList()
    {
        var clients = _context.Clients.ToList();
        return clients;
    }
}

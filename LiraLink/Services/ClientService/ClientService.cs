using LiraLink.DataContext;
using LiraLink.Models;

namespace LiraLink.Services.ClientService;

public class ClientService : IClientService
{
    private readonly ApplicationDbContext _context;
    public ClientService(ApplicationDbContext context) 
    {
        _context = context;
    }
    public Task<ServiceResponse<List<ClientsModel>>> CreateClient(ClientsModel client)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<ClientsModel>> GetClientById(int clientId)
    {
        throw new NotImplementedException();
    }

    public async Task<ServiceResponse<List<ClientsModel>>> GetClients()
    {
        ServiceResponse<List<ClientsModel>> serviceResponse = new ServiceResponse<List<ClientsModel>>();

        try
        {
            serviceResponse.Data = _context.Clients.ToList();
        }
        catch (Exception ex) 
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public Task<ServiceResponse<List<ClientsModel>>> UpdateClient(ClientsModel client)
    {
        throw new NotImplementedException();
    }
}

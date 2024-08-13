using LiraLink.DataContext;
using LiraLink.DTOs;
using LiraLink.Models;
using LiraLink.Repositories.ClientRepository;

namespace LiraLink.Services.ClientService;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    public ClientService(IClientRepository clientRepository) 
    {
        _clientRepository = clientRepository;
    }

    public async Task<ServiceResponse<ClientsModel>> CreateClient(ClientDto clientDto)
    {
        ServiceResponse<ClientsModel> serviceResponse = new ServiceResponse<ClientsModel>();
        var clientExists = await _clientRepository.GetClientByName(clientDto.Name);

        if(clientExists is not null)
        {
            serviceResponse.Message = "There is already a client with that name";
            serviceResponse.Success = false;
            serviceResponse.StatusCode = 400;

            return serviceResponse;
        }

        var client = await _clientRepository.CreateClient(clientDto);

        serviceResponse.Message = "Customer successfully registered";
        serviceResponse.Data = client;
        serviceResponse.StatusCode = 201;

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<ClientsModel>>> GetClients()
    {
        ServiceResponse<List<ClientsModel>> serviceResponse = new ServiceResponse<List<ClientsModel>>();

        try
        {
            serviceResponse.Data = await _clientRepository.GetClientList();
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<ClientsModel>> GetClient(int id)
    {
        ServiceResponse<ClientsModel> serviceResponse = new ServiceResponse<ClientsModel>();

        try
        {
            var client = await _clientRepository.GetClientById(id);
            if (client is null)
            {
                serviceResponse.Message = "Client not found";
                serviceResponse.Success = false;
                serviceResponse.StatusCode = 404;

                return serviceResponse;
            }
            serviceResponse.Data = client;
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<ClientsModel>> UpdateClient(int id, ClientDto clientDto)
    {
        ServiceResponse<ClientsModel> serviceResponse = new ServiceResponse<ClientsModel>();
        var clientExists = await _clientRepository.GetClientById(id);

        if (clientExists is null)
        {
            serviceResponse.Message = "Client not found";
            serviceResponse.Success = false;
            serviceResponse.StatusCode = 404;

            return serviceResponse;
        }

        var client = await _clientRepository.UpdateClient(clientExists, clientDto);

        serviceResponse.Message = "Client updated successfully";
        serviceResponse.Data = client;
        serviceResponse.StatusCode = 200;

        return serviceResponse;
    }
}

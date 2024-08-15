using LiraLink.DataContext;
using LiraLink.DTOs;
using LiraLink.Models;
using LiraLink.Repositories.ClientRepository;
using LiraLink.Services.PositionService;

namespace LiraLink.Services.ClientService;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clientRepository;
    public ClienteService(IClienteRepository clientRepository) 
    {
        _clientRepository = clientRepository;
    }

    public async Task<ServiceResponse<ClienteModel>> CriaCliente(ClienteDto clientDto)
    {
        ServiceResponse<ClienteModel> serviceResponse = new ServiceResponse<ClienteModel>();
        var clientExists = await _clientRepository.BuscaClientePorNome(clientDto.nome);

        if (clientExists is not null)
        {
            serviceResponse.Message = "There is already a client with that name";
            serviceResponse.Success = false;
            serviceResponse.StatusCode = 400;

            return serviceResponse;
        }

        var client = await _clientRepository.CriaCliente(clientDto);

        serviceResponse.Message = "Client successfully registered";
        serviceResponse.Data = client;
        serviceResponse.StatusCode = 201;

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<ClienteModel>>> ListaClientes()
    {
        ServiceResponse<List<ClienteModel>> serviceResponse = new ServiceResponse<List<ClienteModel>>();

        try
        {
            serviceResponse.Data = await _clientRepository.ListaClientes();
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<ClienteModel>> BuscaCliente(int id)
    {
        ServiceResponse<ClienteModel> serviceResponse = new ServiceResponse<ClienteModel>();

        try
        {
            var client = await _clientRepository.BuscaClientePorId(id);
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

    public async Task<ServiceResponse<ClienteModel>> AtualizaCliente(int id, ClienteDto clientDto)
    {
        ServiceResponse<ClienteModel> serviceResponse = new ServiceResponse<ClienteModel>();
        var clientExists = await _clientRepository.BuscaClientePorId(id);

        if (clientExists is null)
        {
            serviceResponse.Message = "Client not found";
            serviceResponse.Success = false;
            serviceResponse.StatusCode = 404;

            return serviceResponse;
        }

        var client = await _clientRepository.AtualizaCliente(clientExists, clientDto);

        serviceResponse.Message = "Client updated successfully";
        serviceResponse.Data = client;
        serviceResponse.StatusCode = 200;

        return serviceResponse;
    }
}

using AutoMapper;
using LiraLink.DataContext;
using LiraLink.DTOs;
using LiraLink.Models;
using Microsoft.EntityFrameworkCore;

namespace LiraLink.Repositories.ClientRepository;

public class ClientRepository : IClientRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public ClientRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<ClientsModel>?> GetClientList()
    {
        return await _context.Clients.ToListAsync();
    }

    public async Task<ClientsModel?> GetClientByName(string name)
    {
        var client = await _context.Clients.FirstOrDefaultAsync(d => d.Name == name);
        return client;
    }

    public async Task<ClientsModel?> GetClientById(int id)
    {
        var client = await _context.Clients.FirstOrDefaultAsync(d => d.Id == id);
        return client;
    }

    public async Task<ClientsModel> CreateClient(ClientDto clientDto)
    {
        var client = _mapper.Map<ClientsModel>(clientDto);
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        return client;
    }

    public async Task<ClientsModel> UpdateClient(ClientsModel client, ClientDto data)
    {
        client.Name = data.Name;
        _context.Clients.Update(client);
        await _context.SaveChangesAsync();
        return client;
    }
}

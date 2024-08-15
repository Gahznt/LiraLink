using AutoMapper;
using LiraLink.DataContext;
using LiraLink.DTOs;
using LiraLink.Models;
using Microsoft.EntityFrameworkCore;

namespace LiraLink.Repositories.ClientRepository;

public class ClienteRepository : IClienteRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public ClienteRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<ClienteModel>?> ListaClientes()
    {
        return await _context.Cliente.ToListAsync();
    }

    public async Task<ClienteModel?> BuscaClientePorNome(string nome)
    {
        var cliente = await _context.Cliente.FirstOrDefaultAsync(d => d.nome == nome);
        return cliente;
    }

    public async Task<ClienteModel?> BuscaClientePorId(int id)
    {
        var cliente = await _context.Cliente.FirstOrDefaultAsync(d => d.id == id);
        return cliente;
    }

    public async Task<ClienteModel> CriaCliente(ClienteDto clientDto)
    {
        var cliente = _mapper.Map<ClienteModel>(clientDto);
        _context.Cliente.Add(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }

    public async Task<ClienteModel> AtualizaCliente(ClienteModel cliente, ClienteDto data)
    {
        cliente.nome = data.nome;
        cliente.email = data.email;
        cliente.telefone = data.telefone;
        _context.Cliente.Update(cliente);
        await _context.SaveChangesAsync();
        return cliente;
    }
}

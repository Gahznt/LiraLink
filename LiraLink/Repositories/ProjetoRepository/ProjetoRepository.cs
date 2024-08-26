using AutoMapper;
using LiraLink.DataContext;
using LiraLink.DTOs;
using LiraLink.Models;
using Microsoft.EntityFrameworkCore;

namespace LiraLink.Repositories.ProjetoRepository;

public class ProjetoRepository : IProjetoRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public ProjetoRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ProjetoModel> AtualizarAsync(ProjetoModel projeto, ProjetoDto data)
    {
        _mapper.Map(data, projeto);
        projeto.updated_at = DateTime.Now;

        await _context.SaveChangesAsync();
        return projeto;
    }

    public async Task<ProjetoModel?> BuscaPorIdAsync(int id)
    {
        var projeto = await _context.Projetos.FirstOrDefaultAsync(d => d.id == id);
        return projeto;
    }

    public async Task<ProjetoModel?> BuscaPorNomeAsync(string nome)
    {
        var cliente = await _context.Projetos.FirstOrDefaultAsync(d => d.nome.ToLower().Contains(nome.ToLower()));
        return cliente;
    }

    public async Task<ProjetoModel> CriarAsync(ProjetoModel projeto)
    {
        _context.Projetos.Add(projeto);
        await _context.SaveChangesAsync();
        return projeto;
    }

    public async Task<List<ProjetoModel>?> ListarAsync()
    {
        return await _context.Projetos.ToListAsync();
    }
}
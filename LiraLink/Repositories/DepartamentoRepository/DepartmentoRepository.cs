using LiraLink.DataContext;
using LiraLink.DTOs;
using LiraLink.Models;
using Microsoft.EntityFrameworkCore;

namespace LiraLink.Repositories.DepartmentRepository;

public class DepartmentoRepository : IDepartmentoRepository
{
    private readonly ApplicationDbContext _context;
    public DepartmentoRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<DepartamentoModel> CriaAsync(DepartamentoModel departamento)
    {
        _context.Departamentos.Add(departamento);
        await _context.SaveChangesAsync();

        return departamento;
    }

    public async Task<List<DepartamentoModel>> ListaAsync()
    {
        return await _context.Departamentos.ToListAsync();
    }

    public async Task<DepartamentoModel?> BuscaPorIdAsync(int id)
    {
        var departamento = await _context.Departamentos.FirstOrDefaultAsync(d => d.id == id);
        return departamento;
    }

    public async Task<DepartamentoModel?> BuscaPorNomeAsync(string nome)
    {
        var departamento = await _context.Departamentos.FirstOrDefaultAsync(d => d.nome == nome);
        return departamento;
    }

    public async Task<DepartamentoModel> AtualizaAsync(DepartamentoModel departamento, DepartamentoDto data)
    {
        departamento.nome = data.nome;
        _context.Departamentos.Update(departamento);
        await _context.SaveChangesAsync();
        return departamento;
    }
}

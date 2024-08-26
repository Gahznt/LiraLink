using LiraLink.DataContext;
using LiraLink.Models;
using Microsoft.EntityFrameworkCore;

namespace LiraLink.Repositories.ProjetoDepartamentoRepository;

public class ProjetoDepartamentoRepository : IProjetoDepartamentoRepository
{
    private readonly ApplicationDbContext _context;
    public ProjetoDepartamentoRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<ProjetoDepartamentosModel> CriarAsync(ProjetoDepartamentosModel data)
    {
        _context.ProjetoDepartamentos.Add(data);
        await _context.SaveChangesAsync();
        return data;
    }
}

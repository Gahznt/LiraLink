using AutoMapper;
using LiraLink.DataContext;
using LiraLink.DTOs;
using LiraLink.Models;
using Microsoft.EntityFrameworkCore;

namespace LiraLink.Repositories.PositionsRepository;

public class CargoRepository : ICargoRepository
{
    private readonly ApplicationDbContext _context;
    public CargoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CargoModel> CriaAsync(CargoModel cargo)
    {
        _context.Cargos.Add(cargo);
        await _context.SaveChangesAsync();

        return cargo;
    }

    public async Task<List<CargoModel>> ListaAsync()
    {
        return await _context.Cargos.ToListAsync();
    }

    public async Task<CargoModel?> BuscaPorIdAsync(int id)
    {
        var cargo = await _context.Cargos.FirstOrDefaultAsync(d => d.id == id);
        return cargo;
    }

    public async Task<CargoModel?> BuscaPorNomeAsync(string nome)
    {
        var cargo = await _context.Cargos.FirstOrDefaultAsync(d => d.nome == nome);
        return cargo;
    }

    public async Task<CargoModel> AtualizaAsync(CargoModel cargo, PositionDto data)
    {
        cargo.nome = data.nome;
        _context.Cargos.Update(cargo);
        await _context.SaveChangesAsync();
        return cargo;
    }
}

using AutoMapper;
using LiraLink.DataContext;
using LiraLink.DTOs;
using LiraLink.Models;
using Microsoft.EntityFrameworkCore;

namespace LiraLink.Repositories.IndicatorsTypeRepository;

public class TipoIndicadoresRepository : ITipoIndicadoresRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public TipoIndicadoresRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TipoIndicadorModel>?> ListaAsync()
    {
        return await _context.TipoIndicadores.ToListAsync();
    }

    public async Task<TipoIndicadorModel> CriaAsync(TipoIndicadoreseDto indicatorTypeDto)
    {
        var iType = _mapper.Map<TipoIndicadorModel>(indicatorTypeDto);
        _context.TipoIndicadores.Add(iType);
        await _context.SaveChangesAsync();

        return iType;
    }
}

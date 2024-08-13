using AutoMapper;
using LiraLink.DataContext;
using LiraLink.DTOs;
using LiraLink.Models;
using Microsoft.EntityFrameworkCore;

namespace LiraLink.Repositories.IndicatorsTypeRepository;

public class IndicatorsTypeRepository : IIndicatorsTypeRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    public IndicatorsTypeRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<IndicatorTypesModel>?> List()
    {
        return await _context.IndicatorTypes.ToListAsync();
    }

    public async Task<IndicatorTypesModel> Create(IndicatorsTypeDto indicatorTypeDto)
    {
        var iType = _mapper.Map<IndicatorTypesModel>(indicatorTypeDto);
        _context.IndicatorTypes.Add(iType);
        await _context.SaveChangesAsync();

        return iType;
    }
}

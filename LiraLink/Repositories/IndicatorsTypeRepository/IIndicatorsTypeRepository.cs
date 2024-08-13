using LiraLink.DTOs;
using LiraLink.Models;

namespace LiraLink.Repositories.IndicatorsTypeRepository;

public interface IIndicatorsTypeRepository
{
    Task<IndicatorTypesModel> Create(IndicatorsTypeDto indicatorTypeDto);
}

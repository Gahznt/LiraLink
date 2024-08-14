using AutoMapper;
using LiraLink.DTOs;
using LiraLink.Models;
using LiraLink.Repositories.PositionsRepository;

namespace LiraLink.Services.PositionService;

public class CargoService : ICargoService
{
    private readonly ICargoRepository _repository;
    private readonly IMapper _mapper;
    public CargoService(ICargoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ServiceResponse<CargoModel>> CriaAsync(PositionDto position)
    {
        {
            ServiceResponse<CargoModel> serviceResponse = new ServiceResponse<CargoModel>();
            var clientExists = await _repository.BuscaPorNomeAsync(position.nome);

            if (clientExists is not null)
            {
                serviceResponse.Message = "There is already a position with that name";
                serviceResponse.Success = false;
                serviceResponse.StatusCode = 400;

                return serviceResponse;
            }
           
            var newPosition = await _repository.CriaAsync(_mapper.Map<CargoModel>(position));

            serviceResponse.Message = "Position successfully registered";
            serviceResponse.Data = newPosition;
            serviceResponse.StatusCode = 201;

            return serviceResponse;
        }
    }

    public async Task<ServiceResponse<CargoModel>> BuscaPorIdAsync(int id)
    {
        ServiceResponse<CargoModel> serviceResponse = new ServiceResponse<CargoModel>();

        try {
            var position = await _repository.BuscaPorIdAsync(id);
            serviceResponse.Data = position;
            if(position is null)
            {
                serviceResponse.StatusCode = 404;
                serviceResponse.Success = false;
                serviceResponse.Message = "Position not found.";
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<CargoModel>>> ListaAsync()
    {
        ServiceResponse<List<CargoModel>> serviceResponse = new ServiceResponse<List<CargoModel>>();

        try
        {
            var position = await _repository.ListaAsync();
            serviceResponse.Data = position;
            if (position is null)
            {
                serviceResponse.StatusCode = 404;
                serviceResponse.Success = false;
                serviceResponse.Message = "Position not found.";
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<PositionDto>> AtualizaAsync(int id, PositionDto position)
    {
        ServiceResponse<PositionDto> serviceResponse = new ServiceResponse<PositionDto>();
        var departmentExists = await _repository.BuscaPorIdAsync(id);

        if (departmentExists is null)
        {
            serviceResponse.Message = "Position not found";
            serviceResponse.Success = false;
            serviceResponse.StatusCode = 404;

            return serviceResponse;
        }

        var department = await _repository.AtualizaAsync(departmentExists, position);

        serviceResponse.Message = "Position updated successfully";
        serviceResponse.Data = position;
        serviceResponse.StatusCode = 200;

        return serviceResponse;
    }
}

using AutoMapper;
using LiraLink.DTOs;
using LiraLink.Models;
using LiraLink.Repositories.DepartmentRepository;

namespace LiraLink.Services.DepartmentService;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentoRepository _repository;
    private readonly IMapper _mapper;
    public DepartmentService(IDepartmentoRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ServiceResponse<DepartamentoModel>> CriaAsync(DepartamentoDto department)
    {
        {
            ServiceResponse<DepartamentoModel> serviceResponse = new ServiceResponse<DepartamentoModel>();
            var clientExists = await _repository.BuscaPorNomeAsync(department.nome);

            if (clientExists is not null)
            {
                serviceResponse.Message = "There is already a department with that name";
                serviceResponse.Success = false;
                serviceResponse.StatusCode = 400;

                return serviceResponse;
            }

            var newDepartment = await _repository.CriaAsync(_mapper.Map<DepartamentoModel>(department));

            serviceResponse.Message = "Customer successfully registered";
            serviceResponse.Data = newDepartment;
            serviceResponse.StatusCode = 201;

            return serviceResponse;
        }
    }

    public async Task<ServiceResponse<DepartamentoModel>> BuscaPorIdAsync(int id)
    {
        ServiceResponse<DepartamentoModel> serviceResponse = new ServiceResponse<DepartamentoModel>();

        try
        {
            var department = await _repository.BuscaPorIdAsync(id);
            serviceResponse.Data = department;
            if (department is null)
            {
                serviceResponse.StatusCode = 404;
                serviceResponse.Success = false;
                serviceResponse.Message = "Department not found.";
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<DepartamentoModel>>> ListaAsync()
    {
        ServiceResponse<List<DepartamentoModel>> serviceResponse = new ServiceResponse<List<DepartamentoModel>>();

        try
        {
            var department = await _repository.ListaAsync();
            serviceResponse.Data = department;
            if (department is null)
            {
                serviceResponse.StatusCode = 404;
                serviceResponse.Success = false;
                serviceResponse.Message = "Department not found.";
            }
        }
        catch (Exception ex)
        {
            serviceResponse.Message = ex.Message;
            serviceResponse.Success = false;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<DepartamentoModel>> AtualizaAsync(int id, DepartamentoDto departmentDto)
    {
        ServiceResponse<DepartamentoModel> serviceResponse = new ServiceResponse<DepartamentoModel>();
        var departmentExists = await _repository.BuscaPorIdAsync(id);

        if (departmentExists is null)
        {
            serviceResponse.Message = "Department not found";
            serviceResponse.Success = false;
            serviceResponse.StatusCode = 404;

            return serviceResponse;
        }

        var department = await _repository.AtualizaAsync(departmentExists, departmentDto);

        serviceResponse.Message = "Department updated successfully";
        serviceResponse.Data = department;
        serviceResponse.StatusCode = 200;

        return serviceResponse;
    }
}

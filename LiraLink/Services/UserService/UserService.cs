using AutoMapper;
using LiraLink.DTOs;
using LiraLink.Models;
using LiraLink.Repositories.UserRepository;

namespace LiraLink.Services.UserService;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _repository;
    public UserService(IMapper mapper, IUserRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    public async Task<UserDto> Create(UserDto userDto)
    {
        var changedUser = await _repository.CreateUser(userDto);
        return _mapper.Map<UserDto>(changedUser);
    }

    public async Task<UsersModel> GetUserByEmail(string email)
    {
        var user = await _repository.GetUserByEmail(email);
        return user;
    }

    public async Task<UserDto> Update(UserDto userDto)
    {
        var changedUser = await _repository.UpdateUser(userDto);
        return _mapper.Map<UserDto>(changedUser);
    }
}

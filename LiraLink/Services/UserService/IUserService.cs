using LiraLink.DTOs;
using LiraLink.Models;

namespace LiraLink.Services.UserService;

public interface IUserService
{
    Task<UserDto> Create(UserDto user);
    Task<UserDto> Update(UserDto user);
    Task<UsersModel> GetUserByEmail(string email);
}

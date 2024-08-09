using LiraLink.DTOs;
using LiraLink.Models;

namespace LiraLink.Repositories.UserRepository;

public interface IUserRepository
{
    Task<UsersModel> CreateUser(UserDto client);
    Task<UsersModel> UpdateUser(UserDto client);
    Task<UsersModel> GetUserByEmail(string email);
}

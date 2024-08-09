using AutoMapper;
using LiraLink.DataContext;
using LiraLink.DTOs;
using LiraLink.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace LiraLink.Repositories.UserRepository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UserRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UsersModel> CreateUser(UserDto userDto)
    {
        var user = _mapper.Map<UsersModel>(userDto);

        using (var hmac = new HMACSHA512())
        {
            user.Salt = hmac.Key; // O 'Key' do HMACSHA512 é usado como Salt
            user.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password));
        }

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<UsersModel> GetUserByEmail(string email)
    {
        var user = await _context.Users.Where(u => u.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
        return user;
    }

    public async Task<UsersModel> UpdateUser(UserDto userDto)
    {
        var existingUser = await _context.Users.Where(u => u.Email.ToLower() == userDto.Email.ToLower()).FirstOrDefaultAsync();
        existingUser.Name = userDto.Name;
        existingUser.Email = userDto.Email;
        _context.Users.Update(existingUser);
        await _context.SaveChangesAsync();

        return existingUser;
    }
}

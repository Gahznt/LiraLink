
using LiraLink.DataContext;
using LiraLink.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace LiraLink.Services.AuthenticateService;

public class AuthenticateService : IAuthenticateService
{
    private readonly IConfiguration _configuration;
    private readonly IUsuarioRepository _UserRepository;

    public AuthenticateService(IUsuarioRepository userRepository, IConfiguration configuration)
    {
        _configuration = configuration;
        _UserRepository = userRepository;
    }
    public async Task<bool> AuthenticateAsync(string email, string password)
    {
        var user = await _UserRepository.BuscaPorEmail(email);
        if (user == null)
        {
            return false;
        }

        using var hmac = new HMACSHA512(user.salt);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        for (int x = 0; x < computedHash.Length; x++)
        {
            if (computedHash[x] != user.senha[x]) return false;
        }

        return true;
    }

    public string GenerateToken(int id, string email)
    {
        var claims = new[]
        {
            new Claim("id", id.ToString()),
            new Claim("email", email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:secretKey"]));
        var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);
        var expiration = DateTime.UtcNow.AddMinutes(10);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: _configuration["jwt:issuer"],
            audience: _configuration["jwt:audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public async Task<bool> UserExists(string email)
    {
        var user = await _UserRepository.BuscaPorEmail(email);
        if (user == null)
        {
            return false;
        }
        return true;
    }
}

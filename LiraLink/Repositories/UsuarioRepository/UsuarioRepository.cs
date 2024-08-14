using AutoMapper;
using LiraLink.DataContext;
using LiraLink.DTOs;
using LiraLink.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace LiraLink.Repositories.UserRepository;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UsuarioRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UsariosModel> CriarAsync(UsuarioDto userDto)
    {
        var user = _mapper.Map<UsariosModel>(userDto);

        using (var hmac = new HMACSHA512())
        {
            user.salt = hmac.Key; // O 'Key' do HMACSHA512 é usado como Salt
            user.senha = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.senha));
        }

        user.created_at = DateTime.UtcNow;
        user.updated_at = DateTime.UtcNow;

        _context.Usuarios.Add(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<UsariosModel> BuscaPorEmail(string email)
    {
        var usuario = await _context.Usuarios.Where(u => u.email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
        return usuario;
    }

    public async Task<UsariosModel> BuscaPorId(int id)
    {
        var usuario = await _context.Usuarios.Where(u => u.id == id).FirstOrDefaultAsync();
        return usuario;
    }

    public async Task<UsariosModel> AtualizaAsync(UsuarioDto userDto)
    {
        var usuarioExistente = await _context.Usuarios.Where(u => u.email.ToLower() == userDto.email.ToLower()).FirstOrDefaultAsync();
        usuarioExistente.nome = userDto.nome;
        usuarioExistente.email = userDto.email;
        usuarioExistente.updated_at = DateTime.UtcNow;
        _context.Usuarios.Update(usuarioExistente);
        await _context.SaveChangesAsync();

        return usuarioExistente;
    }
}

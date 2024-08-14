using LiraLink.DTOs;
using LiraLink.Models;
using LiraLink.Services.AuthenticateService;
using LiraLink.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace LiraLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly IUsuarioService _userService;
        public UserController(IAuthenticateService authenticateService, IUsuarioService userService)
        {
            _authenticateService = authenticateService;
            _userService = userService;
        }
        [HttpPost("register")]
        [Authorize]
        public async Task<ActionResult<UserToken>> Criar(UsuarioDto userDto)
        {
            var userId = int.Parse(User.FindFirst("id").Value);
            var usuario = await _userService.BuscaPorIdAsync(userId);
            if (usuario.perfil != PerfilEnum.Master)
            {
                var r = GenericReturn("Only master users can access this feature", 401, false);
                return StatusCode(r.StatusCode, r);
            }

            if (userDto is null)
            {
                var r = GenericReturn("Invalid Data", 400, false);
                return StatusCode(r.StatusCode, r);
            }

            var emailExists = await _authenticateService.UserExists(userDto.email);
            if (emailExists)
            {
                var r = GenericReturn("Email is already in use", 400, false);
                return StatusCode(r.StatusCode, r);
            }

            var user = await _userService.CriaAsync(userDto);
            if (user == null)
            {
                var r = GenericReturn("An error occurred while registering.", 400, false);
            }

            return StatusCode(user.StatusCode, user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Login(LoginDto credential)
        {
            var userExists = await _authenticateService.UserExists(credential.email);
            if (!userExists)
            {
                var r = GenericReturn("Not authorized", 401, false);
                return StatusCode(r.StatusCode, r);
            }

            var result = await _authenticateService.AuthenticateAsync(credential.email, credential.senha);
            if (!result)
            {
                var r = GenericReturn("Not authorized", 401, false);
                return StatusCode(r.StatusCode, r);
            }
            var user = await _userService.BuscaPorEmailAsync(credential.email);
            var token = _authenticateService.GenerateToken(user.id, user.email);

            return new UserToken { Token = token };
        }

        private ServiceResponse<UsuarioDto> GenericReturn(string? msg = null, int statusCode = 200, bool success = true)
        {
            ServiceResponse<UsuarioDto> serviceResponse = new ServiceResponse<UsuarioDto>();
            serviceResponse.Success = success;
            serviceResponse.Message = msg;
            serviceResponse.StatusCode = statusCode;
            return serviceResponse;
        }
    }
}

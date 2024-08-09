using LiraLink.DTOs;
using LiraLink.Models;
using LiraLink.Services.AuthenticateService;
using LiraLink.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace LiraLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthenticateService _authenticateService;
        private readonly IUserService _userService;
        public UserController(IAuthenticateService authenticateService, IUserService userService)
        {
            _authenticateService = authenticateService;
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserToken>> Create(UserDto userDto)
        {
            if (userDto is null)
            {
                return BadRequest("Invalid data");
            }

            var emailExists = await _authenticateService.UserExists(userDto.Email);
            if (emailExists)
            {
                return BadRequest("Email is already in use");
            }

            var user = await _userService.Create(userDto);
            if (user == null)
            {
                return BadRequest("Ocorreu um erro ao cadastrar");
            }

            var token = _authenticateService.GenerateToken(user.Id, user.Email);
            return new UserToken
            {
                Token = token
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Login(LoginDto credential)
        {
            var userExists = await _authenticateService.UserExists(credential.Email);
            if (!userExists)
            {
                return Unauthorized("Not authorized");
            }

            var result = await _authenticateService.AuthenticateAsync(credential.Email, credential.Password);
            if (!result)
            {
                return Unauthorized("Not authorized");
            }
            var user = await _userService.GetUserByEmail(credential.Email);
            var token = _authenticateService.GenerateToken(user.Id, user.Email);

            return new UserToken { Token = token };
        }
    }
}

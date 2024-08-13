using LiraLink.DTOs;
using LiraLink.Models;
using LiraLink.Services.ClientService;
using LiraLink.Services.IndicatorsTypeService;
using Microsoft.AspNetCore.Mvc;

namespace LiraLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndicatorsTypeController : ControllerBase
    {
        private readonly IIndicatorsTypeService _service;
        public IndicatorsTypeController(IIndicatorsTypeService service)
        {
            _service = service;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserToken>> Create(IndicatorsTypeDto ITypeDto)
        {
            //var service = await _service.Create(ITypeDto);
            //return StatusCode(service.StatusCode, service);
        }
    }
}

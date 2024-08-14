using LiraLink.DTOs;
using LiraLink.Models;
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
        [HttpPost]
        public async Task<ActionResult<UserToken>> Criar(TipoIndicadoreseDto ITypeDto)
        {
            return Ok();
            //var service = await _service.Create(ITypeDto);
            //return StatusCode(service.StatusCode, service);
        }
    }
}

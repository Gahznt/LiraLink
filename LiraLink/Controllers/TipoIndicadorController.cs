using LiraLink.DTOs;
using LiraLink.Models;
using LiraLink.Services.IndicatorsTypeService;
using Microsoft.AspNetCore.Mvc;

namespace LiraLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoIndicadorController : ControllerBase
    {
        private readonly ITipoIndicadorService _service;
        public TipoIndicadorController(ITipoIndicadorService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<ActionResult<UserToken>> Criar(TipoIndicadoreseDto ITypeDto)
        {
            return Ok();
        }
    }
}

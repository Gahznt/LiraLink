using LiraLink.DTOs;
using LiraLink.Services.PositionService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiraLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CargoController : ControllerBase
    {
        private ICargoService _positionService;
        public CargoController(ICargoService positionService)
        {
            _positionService = positionService;
        }

        [HttpPost]
        public async Task<ActionResult> Criar(PositionDto position)
        {
            var service = await _positionService.CriaAsync(position);
            return StatusCode(service.StatusCode, service);
        }

        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            var service = await _positionService.ListaAsync();
            return StatusCode(service.StatusCode, service);
        }

        [HttpGet("{id?}")]
        public async Task<ActionResult> Buscar([FromRoute] int id)
        {
            var service = await _positionService.BuscaPorIdAsync(id);
            return StatusCode(service.StatusCode, service);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> Atualizar(PositionDto position, [FromRoute] int id)
        {
            var service = await _positionService.AtualizaAsync(id, position);
            return StatusCode(service.StatusCode, service);
        }
    }
}

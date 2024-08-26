using LiraLink.DTOs;
using LiraLink.Services.DepartmentService;
using LiraLink.Services.PositionService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiraLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartamentoController : ControllerBase
    {
        private IDepartmentService _service;
        public DepartamentoController(IDepartmentService departmentService)
        {
            _service = departmentService;
        }

        [HttpPost]
        public async Task<ActionResult> Criar(DepartamentoDto department)
        {
            var service = await _service.CriaAsync(department);
            return StatusCode(service.StatusCode, service);
        }

        [HttpGet]
        public async Task<ActionResult> Listar()
        {
            var service = await _service.ListaAsync();
            return StatusCode(service.StatusCode, service);
        }

        [HttpGet("{id?}")]
        public async Task<ActionResult> Buscar([FromRoute] int id)
        {
            var service = await _service.BuscaPorIdAsync(id);
            return StatusCode(service.StatusCode, service);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<ActionResult> Atualizar(DepartamentoDto department, [FromRoute] int id)
        {
            var service = await _service.AtualizaAsync(id, department);
            return StatusCode(service.StatusCode, service);
        }
    }
}

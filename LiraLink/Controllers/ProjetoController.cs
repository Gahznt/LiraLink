﻿using LiraLink.DTOs;
using LiraLink.Services.ProjetoService;
using LiraLink.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiraLink.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _service;
        private readonly IUsuarioService _usuarioService;
        public ProjetoController(IProjetoService service, IUsuarioService usuarioService)
        {
            _service = service;
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<ActionResult> Criar(ProjetoDto client)
        {
            var id = int.Parse(User.FindFirst("id").Value);
            var usuarioId = await _usuarioService.BuscaPorIdAsync(id);

            var service = await _service.Criar(client, usuarioId.id);

            return StatusCode(service.StatusCode, service);
        }

        [HttpPost("departamento")]
        public async Task<ActionResult> AdicionarDepartamento(ProjetoDepartamentoDto client)
        {
            throw new NotImplementedException();
        }

        [HttpPost("departamento/colaborador")]
        public async Task<ActionResult> AdicionarColaboradorDepartamento(ProjetoDto client)
        {
            throw new NotImplementedException();
        }
    }
}

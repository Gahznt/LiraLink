using LiraLink.DTOs;
using LiraLink.Services.ClientService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LiraLink.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IClienteService _clientService;
    public ClientController(IClienteService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("{id?}")]
    [Authorize]
    public async Task<ActionResult> Buscar([FromRoute]int id )
    {
        var service = await _clientService.BuscaCliente(id);
        return StatusCode(service.StatusCode, service);
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult> Listar()
    {
        var service = await _clientService.ListaClientes();
        return Ok(service);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult> Criar(ClienteDto client)
    {
        var service = await _clientService.CriaCliente(client);
       return StatusCode(service.StatusCode, service);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult> Atualizar(ClienteDto client, [FromRoute] int id)
    {
        var service = await _clientService.AtualizaCliente(id, client);
        return StatusCode(service.StatusCode, service);
    }
}

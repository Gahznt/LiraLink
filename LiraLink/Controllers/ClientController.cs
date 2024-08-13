using LiraLink.DTOs;
using LiraLink.Models;
using LiraLink.Services.ClientService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LiraLink.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;
    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet("{id?}")]
    [Authorize]
    public async Task<ActionResult> GetClient([FromRoute]int id )
    {
        var service = await _clientService.GetClient(id);
        return StatusCode(service.StatusCode, service);
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult> GetClients()
    {
        var service = await _clientService.GetClients();
        return Ok(service);
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult> CreateClient(ClientDto client)
    {
        var service = await _clientService.CreateClient(client);
       return StatusCode(service.StatusCode, service);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult> UpdateClient(ClientDto client, [FromRoute] int id)
    {
        var service = await _clientService.UpdateClient(id, client);
        return StatusCode(service.StatusCode, service);
    }
}

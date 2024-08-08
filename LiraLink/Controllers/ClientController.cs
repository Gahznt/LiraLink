using LiraLink.Services.ClientService;
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
    [HttpGet]
    public async Task<ActionResult> GetClients()
    {
        var service = await _clientService.GetClients();
        return Ok(service);
    }
}

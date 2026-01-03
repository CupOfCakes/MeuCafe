using Application.UseCases.Clients;
using Microsoft.AspNetCore.Mvc;

namespace MeuCafe.Controllers;

[ApiController]
[Route("api/requests")]
public class RequestsController : ControllerBase
{
    private readonly ListClientsUseCase _listClientsUseCase;
    
    public RequestsController(ListClientsUseCase listClientsUseCase)
    {
        _listClientsUseCase = listClientsUseCase;
    }

    [HttpGet("AllClients")]
    public async Task<IActionResult> GetAllClients()
    {
        var result = await _listClientsUseCase.ExecuteAsync();
        return Ok(result);
    }

}

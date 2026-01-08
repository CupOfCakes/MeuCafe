using Application.UseCases.Clients.List;
using Application.UseCases.Clients.Create;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MeuCafe.Controllers;

[ApiController]
[Route("api/requests")]
public class RequestsController : ControllerBase
{
    private readonly ListClientsUseCase _listClientsUseCase;
    private readonly CreateClientUseCase _createClientUseCase;

    public RequestsController(ListClientsUseCase listClientsUseCase, CreateClientUseCase createClientUseCase)
    {
        _listClientsUseCase = listClientsUseCase;
        _createClientUseCase = createClientUseCase;
    }

    [HttpGet("AllClients")]
    public async Task<IActionResult> GetAllClients()
    {
        var result = await _listClientsUseCase.ExecuteAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ClientCreatedDTO>> CreateNewClient(
        [FromBody] ClientCreateRequestDTO dto)
    {
        var result = await _createClientUseCase.ExecuteAsync(dto);

        return Created(result.URL, result);
    }

}

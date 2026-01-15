using Application.UseCases.Clients.List;
using Application.UseCases.Clients.Create;
using Application.UseCases.Clients.Delete;
using Domain.Entities;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Application.Exceptions;

namespace MeuCafe.Controllers;

[ApiController]
[Route("api/client")]
public class RequestsController : ControllerBase
{
    private readonly ListClientsUseCase _listClientsUseCase;
    private readonly CreateClientUseCase _createClientUseCase;
    private readonly DeleteClientUseCase _deleteClientUseCase;

    public RequestsController(
        ListClientsUseCase listClientsUseCase, 
        CreateClientUseCase createClientUseCase, 
        DeleteClientUseCase deleteClientUseCase
        )
    {
        _listClientsUseCase = listClientsUseCase;
        _createClientUseCase = createClientUseCase;
        _deleteClientUseCase = deleteClientUseCase;
    }

    [HttpGet("AllClients")]
    public async Task<IActionResult> GetAllClients()
    {
        var result = await _listClientsUseCase.ExecuteAsync();
        return Ok(result);
    }

    [HttpPost("CreateClient")]
    public async Task<ActionResult<ClientCreatedDTO>> CreateNewClient(
        [FromBody] ClientCreateRequestDTO dto)
    {
        try
        {
            var result = await _createClientUseCase.ExecuteAsync(dto);

            return Created(result.URL, result);
        }
        catch (DomainException ex)
        {
            return BadRequest(new
            {
                error = ex.Message
            });
        }
        catch (Exception)
        {
            return StatusCode(500, new
            {
                error = "Internal server error"
            });
        }
        
    }

    [HttpDelete("DeleteClientById")]
    public async Task<IActionResult> DeleteClientById(Guid id)
    {
        try
        {
            await _deleteClientUseCase.DeleteClientById(id);

            return Ok();
        }
        catch (BusinessException ex) { return BadRequest(ex.Message); }
        catch (ClientNotFoundException ex) { return NotFound(ex.Message); }
        catch (DbUpdateException ex) { return Conflict(ex.Message); }
        catch (UnexpectedException ex) { return  StatusCode(500, ex.Message); }
    }

}

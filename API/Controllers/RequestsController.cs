using Application.UseCases.Users;
using Microsoft.AspNetCore.Mvc;

namespace MeuCafe.Controllers;

[ApiController]
[Route("api/{controller}")]
public class RequestsController : ControllerBase
{
    private readonly ListUsersUseCase _listUsersUseCase;
    
}

using Microsoft.AspNetCore.Mvc;

namespace MeuCafe.Controllers;

[ApiController]
[Route("api/{controller}")]
public class RequestsController : ControllerBase
{
    public IActionResult GetAll()
    {
        return Ok("list");
    }
    
}

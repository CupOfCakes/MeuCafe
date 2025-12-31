using Microsoft.AspNetCore.Mvc;

namespace MeuCafe.Controllers;

[ApiController]
[Route("api/{controller}")]
public class RequestsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok("list");
    }

    [HttpPost]
    public IActionResult CreateNewUser()
    {
     return Ok("sex on the beach");   
    }
    
}

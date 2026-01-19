using Microsoft.AspNetCore.Mvc;
using Application.Repositories;

namespace MeuCafe.Controllers;

[ApiController]
[Route("system")]
public class SystemController : ControllerBase
{
    [HttpGet("warmup")]
    public async Task<IActionResult> Warmup([FromServices] IWarmupService warmup)
    {
        await warmup.ExecuteAsync();
        return Ok();
    }
}
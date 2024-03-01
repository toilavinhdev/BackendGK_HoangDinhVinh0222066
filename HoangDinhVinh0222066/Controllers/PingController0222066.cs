using Microsoft.AspNetCore.Mvc;

namespace HoangDinhVinh0222066.Controllers;

[ApiController]
[Route("api/v1/ping")]
public class PingController0222066 : ControllerBase
{
    [HttpGet]
    public IActionResult Ping()
    {
        return Ok("Pong");
    }
}
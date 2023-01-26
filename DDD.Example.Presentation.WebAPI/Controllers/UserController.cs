using DDD.Example.Presentation.WebAPI.Common;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Example.Presentation.WebAPI.Controllers;

[ApiController]
[Route("auth")]
public class UserController : ApiController
{
    [HttpPost("login")]
    public async Task<IActionResult> Login()
    {
        return Ok();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register()
    {
        return Ok();
    }
}
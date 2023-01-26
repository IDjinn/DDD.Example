using DDD.Example.Application.Authentication.Commands.Register;
using DDD.Example.Application.Authentication.Queries.Login;
using DDD.Example.Presentation.Contracts.Authentication;
using DDD.Example.Presentation.WebAPI.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Example.Presentation.WebAPI.Controllers;

[ApiController]
[Route("auth")]
public class UserController : ApiController
{
    private readonly ISender _mediator;

    public UserController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        var loginQuery = (LoginQuery)loginRequest;
        var authResult = await _mediator.Send(loginQuery);

        return authResult.Match(result =>
            {
                var response = (AuthenticationResponse)result;
                return Ok(response);
            },
            Problem
        );
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        var registerCommand = (RegisterCommand)registerRequest;
        var authResult = await _mediator.Send(registerCommand);

        return authResult.Match(result =>
            {
                var response = (AuthenticationResponse)result;
                return Ok(response);
            },
            Problem
        );
    }
}
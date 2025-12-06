using Identity.Application.Features.Auth.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IMediator mediator) : ControllerBase
{
    [HttpPost("token")]
    public async Task<ActionResult<string>> SignIn([FromBody] SignInCommand command)
    {
        var token = await mediator.Send(command);
        return Ok(token);
    }
}

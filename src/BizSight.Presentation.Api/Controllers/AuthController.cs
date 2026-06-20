using BizSight.Application.DTOs.Authentication;
using BizSight.Application.Features.Auth.Commands.Login;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BizSight.Presentation.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponseDTO>> Login(
        LoginCommand command,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(
            command,
            cancellationToken);

        if (!result.Succeeded)
        {
            return Unauthorized(result);
        }

        return Ok(result);
    }
}
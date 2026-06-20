using BizSight.Application.DTOs.Authentication;
using MediatR;

namespace BizSight.Application.Features.Auth.Commands.Login;

public class LoginCommand : IRequest<LoginResponseDTO>
{
    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}
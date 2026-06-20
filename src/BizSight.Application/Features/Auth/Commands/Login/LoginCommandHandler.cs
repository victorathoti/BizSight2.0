using BizSight.Application.DTOs.Authentication;
using BizSight.Application.Interfaces.Services;
using MediatR;

namespace BizSight.Application.Features.Auth.Commands.Login;

public class LoginCommandHandler
    : IRequestHandler<LoginCommand, LoginResponseDTO>
{
    private readonly IAuthService _authService;

    public LoginCommandHandler(
        IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<LoginResponseDTO> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        var loginRequest = new LoginRequestDTO
        {
            UserName = request.UserName,
            Password = request.Password
        };

        return await _authService.LoginAsync(
            loginRequest,
            cancellationToken);
    }
}
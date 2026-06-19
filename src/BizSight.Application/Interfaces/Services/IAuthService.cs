using BizSight.Application.DTOs.Authentication;

namespace BizSight.Application.Interfaces.Services;

public interface IAuthService
{
    Task<LoginResponseDTO> LoginAsync(
        LoginRequestDTO request,
        CancellationToken cancellationToken = default);
}
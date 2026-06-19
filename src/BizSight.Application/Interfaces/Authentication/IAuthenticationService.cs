using BizSight.Application.DTOs.Authentication;

namespace BizSight.Application.Interfaces.Authentication;

public interface IAuthenticationService
{
    Task<LoginResponseDTO> LoginAsync(LoginRequestDTO request);

    Task<LoginResponseDTO> AzureLoginAsync(string email);

    Task<string> GenerateJwtTokenAsync(Guid userId);
}
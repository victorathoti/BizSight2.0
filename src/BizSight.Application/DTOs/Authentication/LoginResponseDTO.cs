namespace BizSight.Application.DTOs.Authentication;

public class LoginResponseDTO
{
    public bool Succeeded { get; set; }

    public string Message { get; set; } = string.Empty;

    public string Token { get; set; } = string.Empty;

    public string UserName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string CurrentCompany { get; set; } = string.Empty;

    public string DatabaseName { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;
}
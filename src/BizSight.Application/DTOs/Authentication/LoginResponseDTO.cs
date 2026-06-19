namespace BizSight.Application.DTOs.Authentication;

public class LoginResponseDTO
{
    public bool Succeeded { get; set; }

    public string Message { get; set; } = string.Empty;

    public string Token { get; set; } = string.Empty;

    public Guid UserId { get; set; }

    public string UserName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public Guid CompanyId { get; set; }

    public string CompanyName { get; set; } = string.Empty;

    public int TenantId { get; set; }
}
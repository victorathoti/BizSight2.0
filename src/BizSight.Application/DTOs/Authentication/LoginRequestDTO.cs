namespace BizSight.Application.DTOs.Authentication;

public class LoginRequestDTO
{
    public string UserName { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string? CompanyName { get; set; }
}
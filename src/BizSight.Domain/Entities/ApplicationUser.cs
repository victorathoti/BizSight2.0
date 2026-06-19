namespace BizSight.Domain.Entities;

public class ApplicationUser
{
    public Guid Id { get; set; }

    public string UserName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string? PasswordHash { get; set; }

    public string? AzureObjectId { get; set; }

    public bool IsAzureUser { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime? LastLoginDate { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }
        = new List<UserRole>();

    public ICollection<UserCompany> UserCompanies { get; set; }
        = new List<UserCompany>();
}
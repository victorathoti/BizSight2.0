namespace BizSight.Domain.Entities;

public class Company
{
    public Guid Id { get; set; }

    public int TenantId { get; set; }

    public string CompanyName { get; set; } = string.Empty;

    public string DatabaseName { get; set; } = string.Empty;

    public string ServerName { get; set; } = string.Empty;

    public string ServerInstance { get; set; } = string.Empty;

    public bool IsAzure { get; set; }

    public bool IsActive { get; set; }

    public bool IsLocked { get; set; }

    public bool UpgradeRequired { get; set; }

    public string Version { get; set; } = string.Empty;

    public string BusinessType { get; set; } = string.Empty;

    public ICollection<UserCompany> UserCompanies { get; set; }
        = new List<UserCompany>();
}
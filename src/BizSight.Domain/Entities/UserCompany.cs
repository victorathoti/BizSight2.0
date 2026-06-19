namespace BizSight.Domain.Entities;

public class UserCompany
{
    public Guid UserId { get; set; }

    public Guid CompanyId { get; set; }

    /// <summary>
    /// User's preferred company.
    /// Used when last accessed company is unavailable.
    /// </summary>
    public bool IsDefaultCompany { get; set; }

    /// <summary>
    /// User marked as favorite.
    /// Useful when user has many companies.
    /// </summary>
    public bool IsFavoriteCompany { get; set; }

    /// <summary>
    /// Last successfully accessed company.
    /// </summary>
    public DateTime? LastAccessedDateTime { get; set; }

    public ApplicationUser User { get; set; } = null!;

    public Company Company { get; set; } = null!;
}
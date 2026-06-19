namespace BizSight.Domain.Entities;

public class UserCompany
{
    public Guid UserId { get; set; }

    public Guid CompanyId { get; set; }

    public bool IsDefaultCompany { get; set; }

    public bool IsFavoriteCompany { get; set; }

    public DateTime? LastAccessedDateTime { get; set; }

    public ApplicationUser User { get; set; } = null!;

    public Company Company { get; set; } = null!;
}
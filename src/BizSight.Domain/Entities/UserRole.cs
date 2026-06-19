using System.Data;

namespace BizSight.Domain.Entities;

public class UserRole
{
    public Guid UserId { get; set; }

    public Guid RoleId { get; set; }

    public ApplicationUser User { get; set; } = null!;

    public Role Role { get; set; } = null!;
}
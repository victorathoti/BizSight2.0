using BizSight.Domain.Enums;

namespace BizSight.Domain.Entities;

public class RoleFeaturePermission
{
    public Guid RoleId { get; set; }

    public Guid FeatureId { get; set; }

    public AccessLevel AccessLevel { get; set; }

    public Role Role { get; set; } = null!;

    public Feature Feature { get; set; } = null!;
}
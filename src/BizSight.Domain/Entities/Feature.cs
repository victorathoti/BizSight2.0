namespace BizSight.Domain.Entities;

public class Feature
{
    public Guid Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string BusinessArea { get; set; } = string.Empty;

    public ICollection<RoleFeaturePermission> Permissions { get; set; } = new List<RoleFeaturePermission>();
}
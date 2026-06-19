namespace BizSight.Domain.Common;

public abstract class AuditableEntity : BaseEntity
{
    public string? CreatedBy { get; set; }

    public DateTime CreatedDateTime { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDateTime { get; set; }

    public bool IsDeleted { get; set; }
}
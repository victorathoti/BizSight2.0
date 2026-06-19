using BizSight.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BizSight.Persistence.Configurations;

public class RoleFeaturePermissionConfiguration : IEntityTypeConfiguration<RoleFeaturePermission>
{
    public void Configure(EntityTypeBuilder<RoleFeaturePermission> builder)
    {
        builder.ToTable("RoleFeaturePermissions");

        builder.HasKey(x => new
        {
            x.RoleId,
            x.FeatureId
        });

        builder.HasOne(x => x.Role)
            .WithMany(x => x.Permissions)
            .HasForeignKey(x => x.RoleId);

        builder.HasOne(x => x.Feature)
            .WithMany(x => x.Permissions)
            .HasForeignKey(x => x.FeatureId);
    }
}
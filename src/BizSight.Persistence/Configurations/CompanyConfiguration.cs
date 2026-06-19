using BizSight.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BizSight.Persistence.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.CompanyName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.DatabaseName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.ServerName)
            .HasMaxLength(500);

        builder.HasIndex(x => x.TenantId)
            .IsUnique();
    }
}
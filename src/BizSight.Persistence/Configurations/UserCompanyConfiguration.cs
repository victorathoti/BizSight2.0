using BizSight.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BizSight.Persistence.Configurations;

public class UserCompanyConfiguration : IEntityTypeConfiguration<UserCompany>
{
    public void Configure(EntityTypeBuilder<UserCompany> builder)
    {
        builder.ToTable("UserCompanies");

        builder.HasKey(x => new
        {
            x.UserId,
            x.CompanyId
        });

        builder.HasOne(x => x.User)
            .WithMany(x => x.UserCompanies)
            .HasForeignKey(x => x.UserId);

        builder.HasOne(x => x.Company)
            .WithMany(x => x.UserCompanies)
            .HasForeignKey(x => x.CompanyId);
    }
}
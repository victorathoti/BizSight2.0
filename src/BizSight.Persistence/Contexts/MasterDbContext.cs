using BizSight.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BizSight.Persistence.Contexts;

public class MasterDbContext : DbContext
{
    public MasterDbContext(DbContextOptions<MasterDbContext> options)
        : base(options)
    {
    }

    public DbSet<ApplicationUser> ApplicationUsers => Set<ApplicationUser>();

    public DbSet<Company> Companies => Set<Company>();

    public DbSet<UserCompany> UserCompanies => Set<UserCompany>();

    public DbSet<Role> Roles => Set<Role>();

    public DbSet<Feature> Features => Set<Feature>();

    public DbSet<UserRole> UserRoles => Set<UserRole>();

    public DbSet<RoleFeaturePermission> RoleFeaturePermissions => Set<RoleFeaturePermission>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MasterDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
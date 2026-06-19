using Microsoft.EntityFrameworkCore;

namespace BizSight.Persistence.Contexts;

public class TenantDbContext : DbContext
{
    public TenantDbContext(DbContextOptions<TenantDbContext> options)
        : base(options)
    {
    }
}
using BizSight.Application.Interfaces.Repositories;
using BizSight.Persistence.Contexts;

namespace BizSight.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly MasterDbContext _context;

    public UnitOfWork(MasterDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
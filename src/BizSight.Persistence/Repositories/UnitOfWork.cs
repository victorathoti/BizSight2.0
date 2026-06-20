using BizSight.Application.Interfaces.Repositories;
using BizSight.Persistence.Contexts;

namespace BizSight.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly MasterDbContext _context;
    public IUserRepository Users { get; }

    public ICompanyRepository Companies { get; }

    public UnitOfWork(
     MasterDbContext context,
     IUserRepository userRepository,
     ICompanyRepository companyRepository)
    {
        _context = context;

        Users = userRepository;
        Companies = companyRepository;
    }

    public async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
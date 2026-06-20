namespace BizSight.Application.Interfaces.Repositories;

public interface IUnitOfWork
{
    IUserRepository Users { get; }

    ICompanyRepository Companies { get; }

    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default);
}
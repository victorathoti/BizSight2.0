using BizSight.Domain.Entities;

namespace BizSight.Application.Interfaces.Repositories;

public interface ICompanyRepository : IGenericRepository<Company>
{
    Task<List<Company>> GetUserCompaniesAsync(Guid userId);

    Task<Company?> GetDefaultCompanyAsync(Guid userId);

    Task<Company?> GetByDatabaseNameAsync(string databaseName);
}
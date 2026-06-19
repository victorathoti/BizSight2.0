using BizSight.Application.Interfaces.Repositories;
using BizSight.Domain.Entities;
using BizSight.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BizSight.Persistence.Repositories;

public class CompanyRepository
    : GenericRepository<Company>, ICompanyRepository
{
    private readonly MasterDbContext _context;

    public CompanyRepository(MasterDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<List<Company>> GetUserCompaniesAsync(Guid userId)
    {
        return await _context.UserCompanies
            .Where(x => x.UserId == userId)
            .Select(x => x.Company)
            .ToListAsync();
    }

    public async Task<Company?> GetDefaultCompanyAsync(Guid userId)
    {
        return await _context.UserCompanies
            .Where(x => x.UserId == userId && x.IsDefaultCompany)
            .Select(x => x.Company)
            .FirstOrDefaultAsync();
    }

    public async Task<Company?> GetByDatabaseNameAsync(string databaseName)
    {
        return await _context.Companies
            .FirstOrDefaultAsync(x => x.DatabaseName == databaseName);
    }
}
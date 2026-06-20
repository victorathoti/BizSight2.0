using BizSight.Application.Interfaces.Repositories;
using BizSight.Domain.Entities;
using BizSight.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace BizSight.Persistence.Repositories;

public class UserRepository
    : GenericRepository<ApplicationUser>, IUserRepository
{
    private readonly MasterDbContext _context;

    public UserRepository(MasterDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<ApplicationUser?> GetByEmailAsync(string email)
    {
        return await _context.ApplicationUsers
            .FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<ApplicationUser?> GetByUserNameAsync(string userName)
    {
        return await _context.ApplicationUsers
            .FirstOrDefaultAsync(x => x.UserName == userName);
    }

    public async Task<ApplicationUser?> GetUserWithCompaniesAsync(Guid userId)
    {
        return await _context.ApplicationUsers
            .Include(x => x.UserCompanies)
                .ThenInclude(x => x.Company)
            .FirstOrDefaultAsync(x => x.Id == userId);
    }

    public async Task<ApplicationUser?> GetUserWithRolesAsync(Guid userId)
    {
        return await _context.ApplicationUsers
            .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(x => x.Id == userId);
    }

    public async Task<ApplicationUser?> GetUserForLoginAsync(string userNameOrEmail)
    {
        return await DbSet
            .Include(x => x.UserCompanies)
                .ThenInclude(x => x.Company)
            .Include(x => x.UserRoles)
                .ThenInclude(x => x.Role)
            .FirstOrDefaultAsync(x =>
                x.Email == userNameOrEmail ||
                x.UserName == userNameOrEmail);
    }
}
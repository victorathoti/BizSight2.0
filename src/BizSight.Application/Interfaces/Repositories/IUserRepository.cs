using BizSight.Domain.Entities;

namespace BizSight.Application.Interfaces.Repositories;

public interface IUserRepository : IGenericRepository<ApplicationUser>
{
    Task<ApplicationUser?> GetByEmailAsync(string email);

    Task<ApplicationUser?> GetByUserNameAsync(string userName);

    Task<ApplicationUser?> GetUserWithCompaniesAsync(Guid userId);

    Task<ApplicationUser?> GetUserWithRolesAsync(Guid userId);
    Task<ApplicationUser?> GetUserForLoginAsync(
    string userNameOrEmail);
}
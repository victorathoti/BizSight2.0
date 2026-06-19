using BizSight.Domain.Entities;

namespace BizSight.Application.Interfaces.Services;

public interface ITokenService
{
    string GenerateAccessToken(
        ApplicationUser user,
        string companyName,
        string roleName);
}
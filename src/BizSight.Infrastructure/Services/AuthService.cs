using BizSight.Application.DTOs.Authentication;
using BizSight.Application.Interfaces.Repositories;
using BizSight.Application.Interfaces.Services;

namespace BizSight.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasherService _passwordHasher;
    private readonly ITokenService _tokenService;

    public AuthService(
        IUnitOfWork unitOfWork,
        IPasswordHasherService passwordHasher,
        ITokenService tokenService)
    {
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
    }

    public async Task<LoginResponseDTO> LoginAsync(
        LoginRequestDTO request,
        CancellationToken cancellationToken = default)
    {
        var user = await _unitOfWork.Users
            .GetUserForLoginAsync(request.UserName);

        if (user is null)
        {
            return new LoginResponseDTO
            {
                Succeeded = false,
                Message = "Invalid username or password."
            };
        }

        if (!user.IsActive)
        {
            return new LoginResponseDTO
            {
                Succeeded = false,
                Message = "User is inactive."
            };
        }

        if (string.IsNullOrWhiteSpace(user.PasswordHash))
        {
            return new LoginResponseDTO
            {
                Succeeded = false,
                Message = "Password not configured."
            };
        }

        var isValid = _passwordHasher.VerifyPassword(
            user.PasswordHash,
            request.Password);

        if (!isValid)
        {
            return new LoginResponseDTO
            {
                Succeeded = false,
                Message = "Invalid username or password."
            };
        }

        var defaultCompany = user.UserCompanies
            .OrderByDescending(x => x.IsDefaultCompany)
            .FirstOrDefault();

        var role = user.UserRoles
            .FirstOrDefault();

        var companyName =
            defaultCompany?.Company.CompanyName ?? string.Empty;

        var databaseName =
            defaultCompany?.Company.DatabaseName ?? string.Empty;

        var roleName =
            role?.Role.Name ?? "User";

        var token = _tokenService.GenerateAccessToken(
            user,
            companyName,
            roleName);

        user.LastLoginDate = DateTime.UtcNow;

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new LoginResponseDTO
        {
            Succeeded = true,
            Message = "Login successful.",
            Token = token,
            UserName = user.UserName,
            Email = user.Email,
            CurrentCompany = companyName,
            DatabaseName = databaseName,
            Role = roleName
        };
    }
}
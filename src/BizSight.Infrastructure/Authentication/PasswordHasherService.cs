using BizSight.Application.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace BizSight.Infrastructure.Authentication;

public class PasswordHasherService : IPasswordHasherService
{
    private readonly PasswordHasher<string> _passwordHasher = new();

    public string HashPassword(string password)
    {
        return _passwordHasher.HashPassword(
            string.Empty,
            password);
    }

    public bool VerifyPassword(
        string hashedPassword,
        string providedPassword)
    {
        var result = _passwordHasher.VerifyHashedPassword(
            string.Empty,
            hashedPassword,
            providedPassword);

        return result == PasswordVerificationResult.Success;
    }
}
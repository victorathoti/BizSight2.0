using BizSight.Application.Interfaces.Services;
using BizSight.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BizSight.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddScoped<ITokenService, TokenService>();

        return services;
    }
}
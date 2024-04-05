using Infrastructure.Extensions;
using Application.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebApi.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddAppServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddWebApi();
        services.AddInfrastructure(configuration);
        services.AddApplication();

        return services;
    }

    private static IServiceCollection AddWebApi(
        this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddAuth();

        return services;
    }
    
    private static IServiceCollection AddAuth(
        this IServiceCollection services)
    {
        services.AddAuthentication()
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opts =>
            {
                opts.ExpireTimeSpan = TimeSpan.FromMinutes(30);

                opts.Events.OnRedirectToLogin = (context) =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };

                opts.Events.OnRedirectToAccessDenied = (context) =>
                {
                    context.Response.StatusCode = 403;
                    return Task.CompletedTask;
                };
            });

        services.AddAuthorizationBuilder()
            .SetFallbackPolicy(new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build());

        return services;
    }
}
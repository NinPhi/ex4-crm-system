using Application.Services;
using Domain.Repositories.UnitOfWork;
using Infrastructure.Repositories;
using Infrastructure.Repositories.UnitOfWork;
using Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAppDbContext(configuration);
        services.AddRepositories();
        services.AddUnitOfWork();
        services.AddServices();

        return services;
    }

    private static IServiceCollection AddAppDbContext(
        this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString(nameof(AppDbContext));
        services.AddDbContext<AppDbContext>(opts => opts.UseSqlServer(connection));

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IUserRepository, UserRepository>();

        return services;
    }

    private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IPasswordManager, PasswordManager>();

        return services;
    }
}

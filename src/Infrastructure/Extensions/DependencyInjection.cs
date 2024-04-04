using Application.Services;
using Infrastructure.Data.Seed;
using Infrastructure.Repositories;
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
        services.AddServices();
        services.AddDataSeeder(configuration);

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

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IPasswordManager, PasswordManager>();

        return services;
    }

    private static IServiceCollection AddDataSeeder(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddOptions<DataSeedOptions>()
            .Bind(configuration.GetSection(nameof(DataSeedOptions)))
            .ValidateDataAnnotations();

        services.AddTransient<DataSeeder>();

        return services;
    }
}

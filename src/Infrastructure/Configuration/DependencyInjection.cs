using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString(nameof(AppDbContext));
        services.AddDbContext<AppDbContext>(opts => opts.UseSqlServer(connection));

        return services;
    }
}

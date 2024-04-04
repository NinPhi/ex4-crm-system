﻿using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAppDbContext(configuration);

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
}

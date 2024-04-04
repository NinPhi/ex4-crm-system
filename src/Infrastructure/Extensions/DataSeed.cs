using Domain.Enums;
using Infrastructure.Services;

namespace Infrastructure.Extensions;

internal static class DataSeed
{
    private const string DEFAULT_ADMIN_EMAIL = "admin@example.com";
    private const string DEFAULT_ADMIN_PASSWORD = "12345678";
    
    public static ModelBuilder InitialSeed(this ModelBuilder modelBuilder)
    {
        return modelBuilder.AddDefaultAdmin();
    }

    private static ModelBuilder AddDefaultAdmin(this ModelBuilder modelBuilder)
    {
        var passwordManager = new PasswordManager();
        var passwordHash = passwordManager.HashPassword(DEFAULT_ADMIN_PASSWORD);

        var defaultAdmin = new User()
        {
            Id = 1,
            Email = DEFAULT_ADMIN_EMAIL,
            PasswordHash = passwordHash,
            Role = Role.Admin,
        };

        modelBuilder
            .Entity<User>()
            .HasData(defaultAdmin);

        return modelBuilder;
    }
}

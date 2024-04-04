using Application.Services;
using Domain.Enums;
using Microsoft.Extensions.Options;

namespace Infrastructure.Data.Seed;

internal class DataSeeder(
    IOptions<DataSeedOptions> options,
    IPasswordManager passwordManager)
{
    public void Seed(ModelBuilder modelBuilder)
    {
        AddSuperAdmin(modelBuilder);
    }

    private void AddSuperAdmin(ModelBuilder modelBuilder)
    {
        string email = options.Value.SuperAdminEmail;
        string passwordHash = passwordManager.HashPassword(options.Value.SuperAdminPassword);

        var su = new User()
        {
            Id = 1,
            Email = email,
            FullName = "Super Admin",
            PasswordHash = passwordHash,
            Role = Role.Admin,
        };

        modelBuilder.Entity<User>().HasData(su);
    }
}

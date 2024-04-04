using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Seed;

internal record DataSeedOptions
{
    [Required]
    [EmailAddress]
    public required string SuperAdminEmail { get; init; }

    [Required]
    public required string SuperAdminPassword { get; init; }
}
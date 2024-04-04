using System.ComponentModel.DataAnnotations;

namespace WebApi.Contracts;

public record LoginData
{
    [Required]
    [EmailAddress]
    [StringLength(200)]
    public string? Email { get; init; }

    [StringLength(200)]
    [Required]
    public string? Password { get; init; }
}

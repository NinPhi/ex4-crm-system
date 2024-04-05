using Domain.Enums;

namespace Application.Contracts.Users;

public record NewUserRequest
{
    [Required]
    [EmailAddress]
    [StringLength(200)]
    public string? Email { get; init; }

    [StringLength(300)]
    public string? FullName { get; init; }

    [Required]
    [StringLength(200)]
    public string? Password { get; set; }

    [Required]
    [EnumDataType(typeof(Role))]
    public Role? Role { get; set; }
}

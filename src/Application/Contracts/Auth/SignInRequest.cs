namespace Application.Contracts.Auth;

public record SignInRequest
{
    [Required]
    [EmailAddress]
    [StringLength(200)]
    public string? Email { get; init; }

    [Required]
    [StringLength(200)]
    public string? Password { get; init; }
}

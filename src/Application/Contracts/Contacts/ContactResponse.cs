using Domain.Enums;

namespace Application.Contracts.Contacts;

public record ContactResponse
{
    public required long Id { get; init; }

    public required long MarketerId { get; init; }

    public required string FirstName { get; init; }

    public string? MiddleName { get; init; }

    public string? LastName { get; init; }

    public required string Phone { get; init; }

    public string? Email { get; init; }

    public required ContactStatus Status { get; init; }
}

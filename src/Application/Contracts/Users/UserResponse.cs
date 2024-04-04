using Domain.Enums;

namespace Application.Contracts.Users;

public record UserResponse(
    long Id, string? FullName, string Email, Role Role, DateTime? BlockedOn);
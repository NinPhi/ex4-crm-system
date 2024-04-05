using Application.Contracts.Users;
using Domain.Enums;

namespace Application.Features.Users.CreateNewUser;

public record CreateNewUserCommand(
    string Email, string Password, string? FullName, Role Role)
    : IRequest<UserResponse?>;

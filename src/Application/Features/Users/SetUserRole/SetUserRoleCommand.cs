using Domain.Enums;

namespace Application.Features.Users.SetUserRole;

public record SetUserRoleCommand(
    long CurrentUserId, long TargetUserId, Role Role)
    : IRequest<bool>;

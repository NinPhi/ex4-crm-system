namespace Application.Features.Users.SetUserRole;

internal sealed class SetUserRoleHandler(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<SetUserRoleCommand, bool>
{
    public async Task<bool> Handle(
        SetUserRoleCommand request, CancellationToken cancellationToken)
    {
        if (request.CurrentUserId == request.TargetUserId)
            return false;

        bool userExists = await userRepository.SetRoleAsync(
            request.TargetUserId, request.Role);

        if (userExists)
            await unitOfWork.SaveChangesAsync();
        
        return userExists;
    }
}
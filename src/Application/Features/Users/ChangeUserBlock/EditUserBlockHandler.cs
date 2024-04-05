namespace Application.Features.Users.EditUserBlock;

internal sealed class EditUserBlockHandler(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork)
    : IRequestHandler<EditUserBlockCommand, bool>
{
    public async Task<bool> Handle(
        EditUserBlockCommand request, CancellationToken cancellationToken)
    {
        bool userFound;

        if (request.IsBlocked)
        {
            userFound = await userRepository.BlockAsync(request.UserId);
        }
        else
        {
            userFound = await userRepository.UnblockAsync(request.UserId);
        }

        if (userFound) await unitOfWork.SaveChangesAsync();

        return userFound;
    }
}

using Application.Contracts.Users;

namespace Application.Features.Users.CreateNewUser;

internal sealed class CreateNewUserHandler(
    IUserRepository userRepository,
    IPasswordManager passwordManager,
    IUnitOfWork unitOfWork)
    : IRequestHandler<CreateNewUserCommand, UserResponse?>
{
    public async Task<UserResponse?> Handle(
        CreateNewUserCommand request, CancellationToken cancellationToken)
    {
        bool emailTaken = await userRepository.EmailExistsAsync(request.Email);
        if (emailTaken) return null;

        var passwordHash = passwordManager.HashPassword(request.Password);

        var user = request.Adapt<User>();

        user.PasswordHash = passwordHash;

        userRepository.AddNew(user);

        await unitOfWork.SaveChangesAsync();

        var response = user.Adapt<UserResponse>();

        return response;
    }
}

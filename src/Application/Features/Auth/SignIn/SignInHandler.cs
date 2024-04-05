using Application.Contracts.Auth;

namespace Application.Features.Auth.SignIn;

internal sealed class SignInHandler(
    IUserRepository userRepository,
    IPasswordManager passwordManager) :
    IRequestHandler<SignInCommand, SignInResponse?>
{
    public async Task<SignInResponse?> Handle(
        SignInCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmailAsync(request.Email);
        if (user is null) return null;

        bool passwordIsValid = passwordManager.VerifyPassword(request.Password, user.PasswordHash);
        if (passwordIsValid is false) return null;

        bool userIsBlocked = user.BlockedOn.HasValue;
        if (userIsBlocked) return null;

        var response = user.Adapt<SignInResponse>();

        return response;
    }
}

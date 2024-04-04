﻿namespace Application.Features.Auth.SignIn;

internal sealed class SignInHandler(
    IUserRepository userRepository,
    IPasswordManager passwordManager) :
    IRequestHandler<SignInRequest, SignInResponse?>
{
    public async Task<SignInResponse?> Handle(
        SignInRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmailAsync(request.Email);
        if (user is null) return null;

        bool passwordIsValid = passwordManager.Validate(request.Password, user.PasswordHash);
        if (passwordIsValid is false) return null;

        bool userIsBlocked = user.BlockedOn.HasValue;
        if (userIsBlocked) return null;

        var response = user.Adapt<SignInResponse>();

        return response;
    }
}

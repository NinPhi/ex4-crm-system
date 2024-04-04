using Application.Services;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Features.Auth.SignIn;

internal sealed class SignInHandler(
    IUserRepository userRepository,
    IPasswordManager passwordManager) :
    IRequestHandler<SignInRequest, SignInResponse?>
{
    public async Task<SignInResponse?> Handle(
        SignInRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmailAsync(request.Email);
        if (user == null) return null;

        bool passwordValid = passwordManager.Validate(request.Password);
        if (passwordValid is false) return null;

        bool userIsBlocked = user.BlockedOn.HasValue;
        if (userIsBlocked) return null;

        var response = user.Adapt<SignInResponse>();

        return response;
    }
}

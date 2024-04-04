using Application.Contracts.Auth;

namespace Application.Features.Auth.SignIn;

public record SignInCommand(string Email, string Password)
    : IRequest<SignInResponse?>;
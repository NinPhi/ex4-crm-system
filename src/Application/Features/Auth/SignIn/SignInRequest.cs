using MediatR;

namespace Application.Features.Auth.SignIn;

public record SignInRequest(string Email, string Password)
    : IRequest<SignInResponse?>
{ }

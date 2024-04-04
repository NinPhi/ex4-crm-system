namespace Application.Contracts.Auth;

public record SignInResponse(
    long Id, string Email, string Role);
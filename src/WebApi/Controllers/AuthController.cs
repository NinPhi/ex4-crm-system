using Application.Contracts.Auth;
using Application.Features.Auth.SignIn;
using Microsoft.AspNetCore.Authentication;

namespace WebApi.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/auth")]
public class AuthController(ISender sender) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(SignInRequest request)
    {
        var command = request.Adapt<SignInCommand>();

        var response = await sender.Send(command);

        if (response is null)
            return Unauthorized("User credentials are invalid or the user is blocked.");

        await HttpContext.SignInAsync(
            response.Id.ToString(),
            response.Email,
            response.Role.ToString());

        return NoContent();
    }

    [HttpGet("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();

        return NoContent();
    }
}

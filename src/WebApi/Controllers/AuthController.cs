using Application.Features.Auth.SignIn;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/auth")]
public class AuthController(ISender sender) : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login(Application.Contracts.Auth.SignInRequest data)
    {
        var request = data.Adapt<Application.Features.Auth.SignIn.SignInCommand>();

        var response = await sender.Send(request);

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

using Application.Features.Auth.SignIn;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(ISender sender) : ControllerBase
{
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginData data)
    {
        var request = data.Adapt<SignInRequest>();

        var response = await sender.Send(request);

        if (response is null)
            return Unauthorized("User credentials are invalid or the user is blocked.");

        await HttpContext.SignInAsync(
            response.Id.ToString(),
            response.Email,
            response.Role.ToString());

        return NoContent();
    }
}
